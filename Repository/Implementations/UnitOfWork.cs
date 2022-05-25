using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private VideoDbContext context = new VideoDbContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<Video> videoRepository;
        private GenericRepository<Comment> commentRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public GenericRepository<Video> VideoRepository
        {
            get
            {

                if (this.videoRepository == null)
                {
                    this.videoRepository = new GenericRepository<Video>(context);
                }
                return videoRepository;
            }
        }
        public GenericRepository<Comment> CommentRepository
        {
            get
            {

                if (this.commentRepository == null)
                {
                    this.commentRepository = new GenericRepository<Comment>(context);
                }
                return commentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
