using System;
using Columbo.Minesweeper.Application.Events;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Minesweeper : IMinesweeper
    {          
        private IMinefield _minefield;
        private Guid _game_id;
        private bool _game_ended_in_a_loss;
        private bool _game_ended_in_a_win;

        public Minesweeper()
        {
            
        }

        public Minesweeper(IMinefieldFactory minefield_factory, GameOptions game_options)
        {
            _game_id = game_options.player_id;

            DomainEvents.raise(new MinesweeperGameStarted(_game_id));
           
            _minefield = minefield_factory.create_a_mindfield_with_these_options(game_options, _game_id);            
        }

        public Guid game_id 
        {
            get { return _game_id; }
        }

        public void reveal_tile_at(Coordinate coordinate)
        {
            listen_for_minefield_events();

            _minefield.reveal_tile_at(coordinate);
        }

        public bool is_game_won()
        {
            return _game_ended_in_a_win;
        }

        public bool is_game_lost()
        {
            return _game_ended_in_a_loss;
        }

        private void listen_for_minefield_events()
        {
            _minefield.mine_exploded += game_lost;
            _minefield.minefield_cleared += game_won;
        }

        private void game_lost(object sender, EventArgs e)
        {
            _game_ended_in_a_loss = true;

            DomainEvents.raise(new MinesweeperGameLost(_game_id));
        }

        void game_won(object sender, EventArgs e)
        {
            _game_ended_in_a_win = true;

            DomainEvents.raise(new MinesweeperGameWon(_game_id));
        }
    }
}