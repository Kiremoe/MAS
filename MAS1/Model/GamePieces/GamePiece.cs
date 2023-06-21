using System.ComponentModel.DataAnnotations;

namespace MAS2.GamePieces
{
    abstract public class GamePiece
    {
        public int Id { get; set; } 

        public DateTime CreationDate { get; } = DateTime.UtcNow;
    }
}
