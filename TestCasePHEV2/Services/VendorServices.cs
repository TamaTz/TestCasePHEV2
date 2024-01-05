using System;
using System.Collections.Generic;
using System.Linq;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repository;

public class VendorServices
{
    private readonly VendorRepository _vendorRepository;

    public VendorServices(TestCasePHEV2DbContext context)
    {
        _vendorRepository = new VendorRepository(context);
    }
    public Vendor CreateVendor(Vendor vendorDto)
    {
        var newVendor = new Vendor
        {
            Guid = Guid.NewGuid().ToString(),
            BusinessField = vendorDto.BusinessField,
            CompanyType = vendorDto.CompanyType,
            CompanyGuid = vendorDto.CompanyGuid,
        };

        var createdVendor = _vendorRepository.Add(newVendor);

        if (createdVendor == null) return null;

        var createdVendorDto = new Vendor
        {
            Guid = createdVendor.Guid,
            BusinessField = vendorDto.BusinessField,
            CompanyType = vendorDto.CompanyType,
            CompanyGuid = vendorDto.CompanyGuid,
        };

        return createdVendorDto;
    }

    public Vendor GetVendorByGuid(string guid)
    {
        var vendor = _vendorRepository.GetByGuid(guid);

        if (vendor != null)
        {
            return vendor;
        }

        return null;
    }

    public IEnumerable<Vendor> GetAllVendor()
    {
        return _vendorRepository.GetAll();
    }

    // UPDATE
    public void UpdateVendor(Vendor updatedVendor)
    {
        _vendorRepository.Update(updatedVendor);
    }

    // DELETE

    public void DeleteVendor(string guid)
    {
        try
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor != null)
            {
                _vendorRepository.Delete(vendor);
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            Console.WriteLine(ex.ToString());
            // You may want to throw an exception or return a specific result here
        }
    }
}