using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;
        private ILikesRepository _likesRepository;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository 
        {
            get
            {
                return _userRepository ??= new UserRepository(_context, _mapper);
            }
        }

        public IMessageRepository MessageRepository
        {
            get
            {  
                return _messageRepository ??= new MessageRepository(_context, _mapper);
            }
        }

        public ILikesRepository LikesRepository
        {
            get
            {
                return _likesRepository ??= new LikesRepository(_context);
            }
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}