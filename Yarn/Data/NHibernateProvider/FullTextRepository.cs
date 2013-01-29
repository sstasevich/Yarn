﻿using Yarn;

namespace Yarn.Data.NHibernateProvider
{
    public class FullTextRepository : Repository, IFullTextRepository
    {
        private IFullTextProvider _fullTextProvider;

        public FullTextRepository()
            : this(null)
        { }

        public FullTextRepository(string contextKey = null)
            : base(contextKey)
        { }

        public IFullTextProvider FullText
        {
            get
            {
                if (_fullTextProvider == null)
                {
                    _fullTextProvider = ObjectFactory.Resolve<IFullTextProvider>(_contextKey);
                    _fullTextProvider.DataContext = this.DataContext;
                }
                return _fullTextProvider;
            }
        }
    }
}
