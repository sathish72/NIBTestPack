using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessService.Entities
{
    using System.Linq;

    #region Unit of work

    public partial interface IMbsContext : IBaseContext
    {
        System.Data.Entity.DbSet<LoanTracking_Expense> LoanTracking_Expenses { get; set; } // Expense
        System.Data.Entity.DbSet<LoanTracking_LoanApplicant> LoanTracking_LoanApplicants { get; set; } // LoanApplicant
        System.Data.Entity.DbSet<LoanTracking_Money> LoanTracking_Moneys { get; set; } // Money

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class MbsContext : System.Data.Entity.DbContext, IMbsContext
    {
        public System.Data.Entity.DbSet<LoanTracking_Expense> LoanTracking_Expenses { get; set; } // Expense
        public System.Data.Entity.DbSet<LoanTracking_LoanApplicant> LoanTracking_LoanApplicants { get; set; } // LoanApplicant
        public System.Data.Entity.DbSet<LoanTracking_Money> LoanTracking_Moneys { get; set; } // Money

        static MbsContext()
        {
            System.Data.Entity.Database.SetInitializer<MbsContext>(null);
        }

        public MbsContext()
            : base("Name=TestPack")
        {
            InitializePartial();
        }

        public MbsContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public MbsContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public MbsContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public MbsContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new LoanTracking_ExpenseConfiguration());
            modelBuilder.Configurations.Add(new LoanTracking_LoanApplicantConfiguration());
            modelBuilder.Configurations.Add(new LoanTracking_MoneyConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new LoanTracking_ExpenseConfiguration(schema));
            modelBuilder.Configurations.Add(new LoanTracking_LoanApplicantConfiguration(schema));
            modelBuilder.Configurations.Add(new LoanTracking_MoneyConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
    }
    #endregion

    #region Fake Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class FakeMbsContext : IMbsContext
    {
        public System.Data.Entity.DbSet<LoanTracking_Expense> LoanTracking_Expenses { get; set; }
        public System.Data.Entity.DbSet<LoanTracking_LoanApplicant> LoanTracking_LoanApplicants { get; set; }
        public System.Data.Entity.DbSet<LoanTracking_Money> LoanTracking_Moneys { get; set; }

        public FakeMbsContext()
        {
            LoanTracking_Expenses = new FakeDbSet<LoanTracking_Expense>("Id");
            LoanTracking_LoanApplicants = new FakeDbSet<LoanTracking_LoanApplicant>("Id");
            LoanTracking_Moneys = new FakeDbSet<LoanTracking_Money>("Id");

            InitializePartial();
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        partial void InitializePartial();

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public System.Data.Entity.Infrastructure.DbChangeTracker _changeTracker;
        public System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get { return _changeTracker; } }
        public System.Data.Entity.Infrastructure.DbContextConfiguration _configuration;
        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get { return _configuration; } }
        public System.Data.Entity.Database _database;
        public System.Data.Entity.Database Database { get { return _database; } }
        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }
        public System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors()
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

    }
    
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class FakeDbSet<TEntity> : System.Data.Entity.DbSet<TEntity>, IQueryable, System.Collections.Generic.IEnumerable<TEntity>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity> where TEntity : class
    {
        private readonly System.Reflection.PropertyInfo[] _primaryKeys;
        private readonly System.Collections.ObjectModel.ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();

            InitializePartial();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();

            InitializePartial();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new System.ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new System.ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        }

        public override System.Collections.Generic.IEnumerable<TEntity> AddRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }

        public override TEntity Add(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override System.Collections.Generic.IEnumerable<TEntity> RemoveRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Remove(entity);
            }
            return items;
        }

        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return System.Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return System.Activator.CreateInstance<TDerivedEntity>();
        }

        public override System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        System.Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<TEntity> System.Collections.Generic.IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator<TEntity> System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }

        partial void InitializePartial();
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class FakeDbAsyncQueryProvider<TEntity> : System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public System.Threading.Tasks.Task<object> ExecuteAsync(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute(expression));
        }

        public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute<TResult>(expression));
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(System.Collections.Generic.IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeDbAsyncEnumerable(System.Linq.Expressions.Expression expression)
            : base(expression)
        { }

        public System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator System.Data.Entity.Infrastructure.IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<T>(this); }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class FakeDbAsyncEnumerator<T> : System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T>
    {
        private readonly System.Collections.Generic.IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(System.Collections.Generic.IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public System.Threading.Tasks.Task<bool> MoveNextAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object System.Data.Entity.Infrastructure.IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    #endregion

    #region POCO classes

    // Expense
    [Table("Expense", Schema = "LoanTracking")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class LoanTracking_Expense : IBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_Expense", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"ApplicantId", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Applicant ID")]
        public int ApplicantId { get; set; } // ApplicantId

        [Column(@"Amount", Order = 3, TypeName = "money")]
        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; } // Amount


        [Column(@"ExpenseType", Order = 4, TypeName = "int")]
        [Required]
        [Display(Name = "ExpenseType")]
        public int ExpenseType { get; set; } // ExpenseType

        [Column(@"Frequency", Order = 5, TypeName = "int")]
        [Required]
        [Display(Name = "Frequency")]
        public int Frequency { get; set; } // ExpenseType

        // Foreign keys

        /// <summary>
        /// Parent LoanTracking_LoanApplicant pointed by [Expense].([ApplicantId]) (FK_Expense_Applicant)
        /// </summary>
        [ForeignKey("ApplicantId")]
        public virtual LoanTracking_LoanApplicant LoanTracking_LoanApplicant { get; set; } // FK_Expense_Applicant
    }

    // LoanApplicant
    [Table("LoanApplicant", Schema = "LoanTracking")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class LoanTracking_LoanApplicant : IBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_Applicant", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"Title", Order = 2, TypeName = "varchar")]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Title")]
        public string Title { get; set; } // Title (length: 30)

        [Column(@"FirstName", Order = 3, TypeName = "varchar")]
        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } // FirstName (length: 200)

        [Column(@"LastName", Order = 4, TypeName = "varchar")]
        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } // LastName (length: 200)

        [Column(@"Created", Order = 5, TypeName = "datetimeoffset")]
        [Required]
        [Display(Name = "Created")]
        public System.DateTimeOffset Created { get; set; } // Created

        [Column(@"LastModified", Order = 6, TypeName = "datetimeoffset")]
        [Required]
        [Display(Name = "Last modified")]
        public System.DateTimeOffset LastModified { get; set; } // LastModified

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(@"FullName", Order = 7, TypeName = "varchar")]
        [MaxLength(401)]
        [StringLength(401)]
        [Display(Name = "Full name")]
        public string FullName { get; private set; } // FullName (length: 401)
    }

    // Money
    [Table("Money", Schema = "LoanTracking")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class LoanTracking_Money : IBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_Money", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"ApplicantId", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Applicant ID")]
        public int ApplicantId { get; set; } // ApplicantId

        [Column(@"Amount", Order = 3, TypeName = "money")]
        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; } // Amount

        [Column(@"IsPrimaryLoan", Order = 4, TypeName = "bit")]
        [Required]
        [Display(Name = "Is primary loan")]
        public bool IsPrimaryLoan { get; set; } // IsPrimaryLoan

        [Column(@"IsLoDocLoan", Order = 5, TypeName = "bit")]
        [Required]
        [Display(Name = "Is lo doc loan")]
        public bool IsLoDocLoan { get; set; } // IsLoDocLoan

        [Column(@"IsFirstHomeBuyer", Order = 6, TypeName = "bit")]
        [Required]
        [Display(Name = "Is first home buyer")]
        public bool IsFirstHomeBuyer { get; set; } // IsFirstHomeBuyer

        [Column(@"IsSelfEmployed", Order = 7, TypeName = "bit")]
        [Required]
        [Display(Name = "Is self employed")]
        public bool IsSelfEmployed { get; set; } // IsSelfEmployed

        [Column(@"ProductName", Order = 8, TypeName = "varchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Product name")]
        public string ProductName { get; set; } // ProductName (length: 150)

        [Column(@"ApprovalNumber", Order = 9, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Approval number")]
        public string ApprovalNumber { get; set; } // ApprovalNumber (length: 50)

        [Column(@"Balance", Order = 10, TypeName = "money")]
        [Required]
        [Display(Name = "Balance")]
        public decimal Balance { get; set; } = 0m; // Balance

        [Column(@"ApplicationDate", Order = 11, TypeName = "date")]
        [Display(Name = "Application date")]
        public System.DateTime? ApplicationDate { get; set; } // ApplicationDate

        [Column(@"SubmissionDate", Order = 12, TypeName = "date")]
        [Display(Name = "Submission date")]
        public System.DateTime? SubmissionDate { get; set; } // SubmissionDate

        // Foreign keys

        /// <summary>
        /// Parent LoanTracking_LoanApplicant pointed by [Money].([ApplicantId]) (FK_Money_Applicant)
        /// </summary>
        //[ForeignKey("ApplicantId")]
        //public virtual LoanTracking_LoanApplicant LoanTracking_LoanApplicant { get; set; } // FK_Money_Applicant
    }

    #endregion

    #region POCO Configuration

    // Expense
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class LoanTracking_ExpenseConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LoanTracking_Expense>
    {
        public LoanTracking_ExpenseConfiguration()
            : this("LoanTracking")
        {
        }

        public LoanTracking_ExpenseConfiguration(string schema)
        {
            Property(x => x.Amount).HasPrecision(19, 4);

            InitializePartial();
        }
        partial void InitializePartial();
    }

    // LoanApplicant
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class LoanTracking_LoanApplicantConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LoanTracking_LoanApplicant>
    {
        public LoanTracking_LoanApplicantConfiguration()
            : this("LoanTracking")
        {
        }

        public LoanTracking_LoanApplicantConfiguration(string schema)
        {
            Property(x => x.Title).IsOptional().IsUnicode(false);
            Property(x => x.FirstName).IsOptional().IsUnicode(false);
            Property(x => x.LastName).IsOptional().IsUnicode(false);
            Property(x => x.FullName).IsUnicode(false);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Money
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class LoanTracking_MoneyConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LoanTracking_Money>
    {
        public LoanTracking_MoneyConfiguration()
            : this("LoanTracking")
        {
        }

        public LoanTracking_MoneyConfiguration(string schema)
        {
            Property(x => x.Amount).HasPrecision(19, 4);
            Property(x => x.ProductName).IsOptional().IsUnicode(false);
            Property(x => x.ApprovalNumber).IsOptional().IsUnicode(false);
            Property(x => x.Balance).HasPrecision(19, 4);
            Property(x => x.ApplicationDate).IsOptional();
            Property(x => x.SubmissionDate).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

    #endregion

}
