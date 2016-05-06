using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Learn.ModelFactory
{
    /// <summary>
    /// Model基类
    /// </summary>
    public class BaseModel
    {
        public BaseModel()
        {
            this.CreateTime = DateTime.Now;
            this.IsDeleted = false;
        }

        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 创建时间(默认当前时间)
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}