using System;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Events
{
    public class TileCreated : IDomainEvent
    {
        public Guid id { get; private set; }
        public Guid game_id { get; private set; }
        public Coordinate coordinate { get; private set; }
        
        public TileCreated(Guid id, Guid game_id, Coordinate coordinate)
        {
            this.id = id;
            this.game_id = game_id;
            this.coordinate = coordinate;
        }
    }
}