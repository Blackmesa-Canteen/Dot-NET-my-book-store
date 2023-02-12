﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyBookStore.Common.constant;
using MyBookStore.DAL.Command.Impl;
using MyBookStore.DAL.Repository;
using MyBookStore.Domain.DTO;

namespace MyBookStore.BLL.Book.Impl
{
    /**
     * author: xiaotian li
     */
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private IMediator _mediator;
        private readonly IMapper _mapper;
        
        public async Task<R> GetAllBooks()
        {
            IEnumerable<Domain.Entity.Book> books = await _bookRepository.FindAll();
            IEnumerable<BookDTO> res = new List<BookDTO>();
            
            foreach (Domain.Entity.Book book in books)
            {
                BookDTO bookDto = new BookDTO(
                    book.BookId,
                    book.Name,
                    book.Description,
                    book.CoverImgUrl,
                    book.UserId
                );

                res.Append(bookDto);
            }

            
            return R.Ok().SetData(res);
        }
        
        public async Task<R> ReserveBook(string bookId, string userId)
        {
            // check reserve info
            Domain.Entity.Book book = await _bookRepository.FindBookByBookId(bookId);
            if (book == null)
            {
                // book not exist
                return R.Error(ExceptionEnum.RESOURCE_NOT_EXIST.GetStatusCode(), "Book Not Found!");
            }

            if (book.UserId != null)
            {
                // book already reserved
                return R.Error(ExceptionEnum.BOOK_ALREADY_RESERVED.GetStatusCode(), ExceptionEnum.BOOK_ALREADY_RESERVED.GetString());
            }
            
            // update the book info
            var command = new ReserveBookCommand();
            command.UserId = userId;
            command.BookId = bookId;

            var result = await _mediator.Send(command);
            if (result.HasErrors())
            {
                // error occured during updating command
                return R.Error().SetData(result.GetErrorList());
            }
            else
            {
                return R.Ok();
            }
        }

        public async Task<R> ReturnBook(string bookId, string userId)
        {
            Domain.Entity.Book book = await _bookRepository.FindBookByBookId(bookId);
            if (book == null)
            {
                // book not exist
                return R.Error(ExceptionEnum.RESOURCE_NOT_EXIST.GetStatusCode(), "Book Not Found!");
            }

            if (book.UserId == null)
            {
                // book not reserved at all
                return R.Error(ExceptionEnum.INVALID_REQUEST_DATA.GetStatusCode(), "Book Not Reserved!");
            }

            if (book.UserId != userId)
            {
                // not the book owner, can not return other's book
                return R.Error(ExceptionEnum.NO_PERMISSION.GetStatusCode(), "The book is not yours, can not return.");
            }

            var command = new ReserveBookCommand();
            command.UserId = null;
            command.BookId = bookId;
            
            var result = await _mediator.Send(command);
            if (result.HasErrors())
            {
                // error occured during updating command
                return R.Error().SetData(result.GetErrorList());
            }
            else
            {
                return R.Ok();
            }
        }
    }
}