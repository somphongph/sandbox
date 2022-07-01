using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Domain.Services.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest<AddBookResponse>
    {
        [Required]
        public string NameTh { get; set; } = String.Empty;

        [Required]
        public string NameEn { get; set; } = String.Empty;

        [Required]
        public string Title { get; set; } = String.Empty;
    }
}