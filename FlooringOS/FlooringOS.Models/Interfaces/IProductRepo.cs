using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models.Interfaces
{
    public interface IProductRepo
    {
        ProductFile LoadProduct(string ProductType);
        List<ProductFile> LoadProducts();
    }
}
