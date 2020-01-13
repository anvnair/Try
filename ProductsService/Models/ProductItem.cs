#region Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

/// <summary>
/// Namespace to hold Product Item 
/// </summary>
namespace ProductService.Models
{
    /// <summary> Class to hold Product Item </summary>
    public class ProductItem
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        /// <summary>Gets or sets the owner.</summary>
        /// <value>The owner.</value>
        public string Owner { get; set; }
        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }
    }
}
