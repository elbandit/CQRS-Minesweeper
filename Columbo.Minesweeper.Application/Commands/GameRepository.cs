using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Infrastructure;
using NHibernate.Linq;

namespace Columbo.Minesweeper.Application.Commands
{
    public class GameRepository : IGameRepository
    {
        public void save(IMinesweeper minesweeper)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction()) 
                {
                    session.Update(minesweeper);

                    trans.Commit();
                }                
            } 
        }

        public IMinesweeper get_by(Guid game_id)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                return session.Get<Application.Domain.Minesweeper>(game_id);                
            } 
        }

        public void delete(IMinesweeper minesweeper)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                session.Delete(minesweeper);
            } 
        }

        public void add(IMinesweeper minesweeper)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.Save(minesweeper);

                    trans.Commit();
                }
            } 
        }
    }
}
