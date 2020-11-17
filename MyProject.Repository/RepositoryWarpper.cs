﻿using MyProject.Contracts;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Repository
{
    public class RepositoryWarpper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IEmployeeRepository _employee;
        private IAppUsersRepository _appUsers;
        private IStallDetailsRepository _stallDetails;
        private IProductCategoryRepository _productCategory;
        private IStallRegistrationRepository _stallRegistration;
        private IStallProductCategoriesRepository _stallProductCategories;
        private IIndentRepository _indentDetails;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }

        public IAppUsersRepository AppUsers
        {
            get
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                }
                return _appUsers;
            }
            set
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                };
            }
            
        }
        public IAppUsersRepository AppUserRoles
        {
            get
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                }
                return _appUsers;
            }
            set
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                };
            }

        }

        public IStallDetailsRepository StallDetails
        {
            get
            {
                if (_stallDetails == null)
                {
                    _stallDetails = new StallDetailsRepository(_repoContext);
                }
                return _stallDetails;
            }
            set
            {
                if (_stallDetails == null)
                {
                    _stallDetails = new StallDetailsRepository(_repoContext);
                };
            }

        }
        public IProductCategoryRepository ProductCategory
        {
            get
            {
                if (_productCategory == null)
                {
                    _productCategory = new ProductCategoryRepository(_repoContext);
                }
                return _productCategory;
            }
            set
            {
                if (_productCategory == null)
                {
                    _productCategory = new ProductCategoryRepository(_repoContext);
                };
            }

        }
        public IStallRegistrationRepository StallRegistration
        {
            get
            {
                if (_stallRegistration == null)
                {
                    _stallRegistration = new StallRegistrationRepository(_repoContext);
                }
                return _stallRegistration;
            }
            set
            {
                if (_stallRegistration == null)
                {
                    _stallRegistration = new StallRegistrationRepository(_repoContext);
                };
            }

        }

        public IStallProductCategoriesRepository StallProductCategories
        {
            get
            {
                if (_stallProductCategories == null)
                {
                    _stallProductCategories = new StallProductCategoriesRepository(_repoContext);
                }
                return _stallProductCategories;
            }
            set
            {
                if (_stallProductCategories == null)
                {
                    _stallProductCategories = new StallProductCategoriesRepository(_repoContext);
                };
            }

        }
        public IIndentRepository IndentDetails
        {
            get
            {
                if (_indentDetails == null)
                {
                    _indentDetails = new IndentRepository(_repoContext);
                }
                return _indentDetails;
            }
            set
            {
                if (_indentDetails == null)
                {
                    _indentDetails = new IndentRepository(_repoContext);
                };
            }

        }
        public RepositoryWarpper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
