using SupplyManagement.Contracts;
using SupplyManagement.DTOs.ManagerLogistic;
using SupplyManagement.Models;

namespace SupplyManagement.Services
{
    public class ManagerLogisticServices
    {
        private readonly IManagerLogistic _managerLogistic;

        public ManagerLogisticServices(IManagerLogistic managerLogistic)
        {
            _managerLogistic = managerLogistic;
        }

        public IEnumerable<GetManagerLogisticDTO>? GetAllManager()
        {
            var manager = _managerLogistic.GetAll();
            if (!manager.Any())
            {
                return null; // manager not found
            }
            var toDto = manager.Select(manager =>
                                                new GetManagerLogisticDTO
                                                {
                                                    ManagerID = manager.ManagerID,
                                                    ManagerName = manager.ManagerName,
                                                    ManagerEmail = manager.ManagerEmail,
                                                    ManagerPhone = manager.ManagerPhone,

                                                }).ToList();
            return toDto; // manager found
        }

        public GetManagerLogisticDTO? GetManagerId(int id)
        {
            var manager = _managerLogistic.GetById(id);
            if (manager is null)
            {
                return null; // manager not found
            }

            var toDto = new GetManagerLogisticDTO
            {
                ManagerID = manager.ManagerID,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
            };

            return toDto; // account roles found
        }

        public GetManagerLogisticDTO? CreateNewManager(NewManagerLogisticDTO newManagerLogisticDTO)
        {
            var manager = new ManagerLogistic
            {
                ManagerName = newManagerLogisticDTO.ManagerName,
                ManagerEmail = newManagerLogisticDTO.ManagerEmail,
                ManagerPhone = newManagerLogisticDTO.ManagerPhone,
            };

            var createdManager = _managerLogistic.Create(manager);
            if (createdManager is null)
            {
                return null; // manager not created
            }

            var toDto = new GetManagerLogisticDTO
            {
                ManagerID = manager.ManagerID,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
            };

            return toDto; // manager created
        }

        public int UpdateManager(UpdateManagerLogisticDTO updateManagerLogisticDTO)
        {
            var isExist = _managerLogistic.IsExist(updateManagerLogisticDTO.ManagerID);
            if (!isExist)
            {
                return -1; // Manager Not Found
            }

            var getManager = _managerLogistic.GetById(updateManagerLogisticDTO.ManagerID);

            var manager = new ManagerLogistic
            {
                ManagerName = updateManagerLogisticDTO.ManagerName,
                ManagerEmail = updateManagerLogisticDTO.ManagerEmail,
                ManagerPhone = updateManagerLogisticDTO.ManagerPhone,
            };

            var isUpdate = _managerLogistic.Update(manager);
            if (!isUpdate)
            {
                return 0; // manager not updated
            }

            return 1;
        }

        public int DeleteManager(int id)
        {
            var isExist = _managerLogistic.IsExist(id);
            if (!isExist)
            {
                return -1; // manager not found
            }

            var manager = _managerLogistic.GetById(id);
            var isDelete = _managerLogistic.Delete(manager);
            if (!isDelete)
            {
                return 0; // manager not deleted
            }

            return 1;
        }
    }
}
