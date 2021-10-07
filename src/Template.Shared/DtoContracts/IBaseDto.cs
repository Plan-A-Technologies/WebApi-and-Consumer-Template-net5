using System;

namespace Template.Shared.DtoContracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseDto<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string UpdatedBy { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}