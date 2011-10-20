using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using NUnit.Framework;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{
    public class MinesweeperSpecs
    {
        [Subject(typeof(Application.Domain.Minesweeper))]
        public class when_starting_a_game : WithFakes
        {
            private Establish context = () =>
            {
                grid_size = 9;
                number_of_mines = 1;
                player_id = Guid.NewGuid();

                var game_difficulty = new GameDifficulty(3, 3, 1);

                game_options = new GameOptions(game_difficulty, player_id);
                
                minefield = An<IMinefield>();

                minefield_factory = An<IMinefieldFactory>();                

                minefield_factory.WhenToldTo(x => x.create_a_mindfield_with_these_options(game_options, Subject)).Return(minefield);
            };

            private Because of = () => Subject = new Application.Domain.Minesweeper(minefield_factory, game_options);

            private It should_create_a_new_mine_field = () =>
            {
                minefield_factory.WasToldTo(x => x.create_a_mindfield_with_these_options(game_options, Subject));
            };
            
            private static int grid_size;
            private static int number_of_mines;
            private static GameOptions game_options;
            private static IMinePlanter mine_planter;
            private static IMinePlanterFactory mine_planter_factory;
            private static IMinefield minefield;
            private static IMinefieldFactory minefield_factory;
            private static IMinesweeper Subject;
            private static Guid player_id;
        }

        [Subject(typeof(Application.Domain.Minesweeper))]
        public class when_revealing_a_tile : WithFakes
        {
            private Establish context = () =>
            {
                minefield_factory = An<IMinefieldFactory>();
                minefield = An<IMinefield>();

                var game_difficulty = new GameDifficulty(3, 3, 1);

                var game_options = new GameOptions(game_difficulty, Guid.NewGuid());
                
                minefield_factory.WhenToldTo(x => x.create_a_mindfield_with_these_options(Arg<GameOptions>.Is.Anything, Arg<IMinesweeper>.Is.Anything)).Return(minefield);

                Subject = new Application.Domain.Minesweeper(minefield_factory, game_options);
            };

            private Because of = () => Subject.reveal_tile_at(coordinate);

            private It should_ask_the_minefield_to_reveal_the_tile = () =>
            {
                minefield.WasToldTo(x => x.reveal_tile_at(coordinate));
            };

            private static Coordinate coordinate;
            private static IMinefield minefield;
            private static IMinesweeper Subject;
            private static IMinefieldFactory minefield_factory;
        }

        [Subject(typeof(Application.Domain.Minesweeper))]
        public class when_revealing_the_last_mine_on_a_minefield : WithFakes
        {
            private Establish context = () =>
            {
                minefield_factory = An<IMinefieldFactory>();
                minefield = An<IMinefield>();

                minefield_factory.WhenToldTo(x => x.create_a_mindfield_with_these_options(Arg<GameOptions>.Is.Anything, Arg<IMinesweeper>.Is.Anything)).Return(minefield);

                coordinate = new Coordinate(1,1);

                var game_difficulty = new GameDifficulty(3, 3, 1);
                var game_options = new GameOptions(game_difficulty, Guid.NewGuid());

                Subject = new Application.Domain.Minesweeper(minefield_factory, game_options);

                Assert.That(Subject.is_game_won(), Is.False);
            };

            private Because of = () => 
            {                                                
                Subject.reveal_tile_at(coordinate);

                minefield.Raise(x => x.minefield_cleared += null, new Object(), EventArgs.Empty);
            };

            private It should_handle_a_minefield_cleared_event_from_the_minefield_and_set_the_game_as_won = () =>
            {
                Assert.That(Subject.is_game_won(), Is.True);
            };
            
            private static Coordinate coordinate;
            private static IMinefield minefield;
            private static IMinesweeper Subject;
            private static IMinefieldFactory minefield_factory;
        }

        [Subject(typeof(Application.Domain.Minesweeper))]
        public class when_revealing_a_tile_that_contains_a_mine : WithFakes
        {
            private Establish context = () =>
            {
                minefield_factory = An<IMinefieldFactory>();
                minefield = An<IMinefield>();

                minefield_factory.WhenToldTo(x => x.create_a_mindfield_with_these_options(Arg<GameOptions>.Is.Anything, Arg<IMinesweeper>.Is.Anything)).Return(minefield);

                coordinate = new Coordinate(1, 1);

                var game_difficulty = new GameDifficulty(3, 3, 1);
                var game_options = new GameOptions(game_difficulty, Guid.NewGuid());

                Subject = new Application.Domain.Minesweeper(minefield_factory, game_options);

                Assert.That(Subject.is_game_lost(), Is.False);
            };

            private Because of = () =>
            {
                Subject.reveal_tile_at(coordinate);

                minefield.Raise(x => x.mine_exploded += null, new Object(), EventArgs.Empty);
            };

            private It should_set_the_game_as_lost = () =>
            {
                Assert.That(Subject.is_game_lost(), Is.True);
            };

            private static Coordinate coordinate;
            private static IMinefield minefield;
            private static IMinesweeper Subject;
            private static IMinefieldFactory minefield_factory;
        }
    }
}