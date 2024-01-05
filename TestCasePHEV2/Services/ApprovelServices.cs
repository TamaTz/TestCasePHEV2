using System;
using System.Collections.Generic;
using System.Linq;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repository;

public class ApprovelServices
{
    private readonly ApprovelRepository _approvelRepository;
    private readonly TestCasePHEV2DbContext _context;

    public ApprovelServices(TestCasePHEV2DbContext context)
    {
        _context = context;
        _approvelRepository = new ApprovelRepository(context);
    }
    //Create
    public Approvel CreateApprovel(Approvel approvelDto)
    {
        var newApprovel = new Approvel
        {
            Guid = Guid.NewGuid().ToString(),
            CompanyGuid = approvelDto.CompanyGuid,
            // Populate other properties from approvalDto
        };

        var createdApproval = _approvelRepository.Add(newApprovel);

        if (createdApproval == null) return null;

        var createdApprovalDto = new Approvel
        {
            Guid = createdApproval.Guid,
            CompanyGuid = createdApproval.CompanyGuid,
            // Populate other properties from approvalDto
        };

        return createdApprovalDto;
    }

    public Approvel GetApprovelByGuid(string guid)
    {
        var approval = _approvelRepository.GetByGuid(guid);

        return approval;
    }

    public IEnumerable<Approvel> GetAllApprovels()
    {
        return _approvelRepository.GetAll();
    }

    // Update
    public void UpdateApprovel(Approvel updatedApprovel)
    {
        _approvelRepository.Update(updatedApprovel);
    }

    // Delete
    public void DeleteApprovel(string guid)
    {
        try
        {
            var approvel = _approvelRepository.GetByGuid(guid);
            if (approvel != null)
            {
                _approvelRepository.Delete(approvel);
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            Console.WriteLine(ex.ToString());
            // You may want to throw an exception or return a specific result here
        }
    }

    public IEnumerable<ApprovelVM> GetTableApprovel()
    {
        // Assuming your PHEDbContext is named _context
        using (var connection = _context.Database.Connection)
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "TableApproval";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (var result = command.ExecuteReader())
                {
                    var companies = new List<ApprovelVM>();

                    while (result.Read())
                    {
                        var company = new ApprovelVM
                        {
                            Guid = result["guid"].ToString(),
                            Name = result["name"].ToString(),
                            Email = result["email"].ToString(),
                            PhoneNumber = result["phone_number"].ToString(),
                            CompanyGuid = result["company_guid"].ToString(),
                            BusinessField = result["business_field"].ToString(),
                            CompanyType = result["company_type"].ToString(),
                        };

                        companies.Add(company);
                    }

                    return companies;
                }
            }
        }
    }
}

