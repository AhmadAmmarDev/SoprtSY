using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportSY.Core;
using SportSY.Core.Models;
using SportSY.Data.Repository.SQL.Models;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace SportSY.Data.Repository.SQL.Repositories
{
    public abstract class SQLRepositoryBase<TModel, TTable> : IRepository<TModel>
        where TModel : Model, new() where TTable : class, new()
    {
     

        public SQLRepositoryBase()
        {
            _db = new SYSportDBContext();
            _table = _db.Set<TTable>();
            if (!IsInitialized)
            {
                var mappingConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TTable, TModel>();
                    cfg.CreateMap<TModel, TTable>();
                });
                Mapper mapper = new Mapper(mappingConfiguration);
                _mapperConfiguration = mappingConfiguration;
                Mapper = mapper;
                IsInitialized = true;
            }
        }

 
        
        private SYSportDBContext _db;
        public SYSportDBContext DB
        {
            get { return _db; }
            set { _db = value; }
        }

        private DbSet<TTable> _table;
        private MapperConfiguration _mapperConfiguration;
        public MapperConfiguration MapperConfiguration
        {
            get { return _mapperConfiguration; }
            set { _mapperConfiguration = value; }
        }
        private static IMapper _mapper;
        public static IMapper Mapper
        {
            get { return _mapper; }
            set { _mapper = value; }
        }
        public static bool IsInitialized { get; set; }
        public virtual IEnumerable<TModel> GetItems()
        {
            var dbItem = _table.ToList();
            List<TModel> modelItmes = new List<TModel>();
            return modelItmes = Mapper.Map(dbItem, modelItmes);
        }

        public virtual void AddItem(TModel newItem)
        {
            var item = Mapper.Map(newItem, new TTable());
            _db.Set<TTable>().Add(item);
            _db.SaveChanges();
        }
        public virtual void EditItem(TModel existItem)
        {
            TTable dbItem = _db.Set<TTable>().Find(existItem.ID);
            TTable dbEntity = Mapper.Map(existItem, dbItem);
            _db.Entry(dbItem).OriginalValues.SetValues(dbEntity);
            _db.SaveChanges();
        }

        public virtual async Task DeleteItem(TModel existItem)
        {
            var dbItem = _db.Set<TTable>().Find(existItem.ID);
            _db.Set<TTable>().Remove(dbItem);
            _db.SaveChanges();
        }       

        public virtual async Task<TModel> GetItemById(TModel item)
        {
            var dbItem = Mapper.Map(item, new TTable());
            return Mapper.Map(DB.Entry(dbItem).Entity, new TModel());
        }
    }

    public abstract class StaticRepositoryBase<TModel, TTable> : SQLRepositoryBase<TModel, TTable>
        where TModel : Model, new()
        where TTable : class, new()
    {
        public override IEnumerable<TModel> GetItems()
        {
            if (!_isInitilised)
            {
                ItemsList = base.GetItems();
                _isInitilised = true;
                return ItemsList;
            }
            else
            {
                return ItemsList;
            }
        }

        public override void AddItem(TModel newItem)
        {
            base.AddItem(newItem);
            ItemsList.ToList().Add(newItem);
        }

        public override void EditItem(TModel existItem)
        {
            base.EditItem(existItem);
            ItemsList.ToList().Remove(existItem);
            ItemsList.ToList().Add(existItem);
        }

        public override Task DeleteItem(TModel existItem)
        {
            return base.DeleteItem(existItem);
            ItemsList.ToList().Remove(existItem);
        }

        public static bool _isInitilised { get; set; }
        public static IEnumerable<TModel> ItemsList { get; set; }
    }
}
