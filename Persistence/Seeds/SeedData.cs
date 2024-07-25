using Core.Security.Entitites;
using Core.Security.Hashing;
using Domain.Entities;
using Domain.Enums;
using Persistence.Contexts;
using Task = Domain.Entities.Task;

namespace Persistence.Seeds
{
	public static class SeedData
	{
		public static void Initialize(CaseAppContext context)
		{
			if (!context.OperationClaims.Any())
			{
				context.OperationClaims.AddRange(
					 new OperationClaim { Id = 1, Name = "Person", CreatedDate = DateTime.UtcNow }
					);
				context.SaveChanges();
			}
			if (!context.UserOperationClaims.Any())
			{
				context.UserOperationClaims.AddRange(
					new UserOperationClaim { Id = 1, UserId = 1, OperationClaimId = 1 },
					new UserOperationClaim { Id = 2, UserId = 2, OperationClaimId = 1 }
					);
				context.SaveChanges();
			}
			if (!context.Regions.Any())
			{
				context.Regions.AddRange(
					 new Region { Id=1, Name="1. Bölge Md."},
					 new Region { Id=2, Name="2. Bölge Md."},
					 new Region { Id=3, Name="3. Bölge Md."},
					 new Region { Id=4, Name="4. Bölge Md."},
					 new Region { Id=5, Name="5. Bölge Md."}
					);
				context.SaveChanges();
			}
			if (!context.Cities.Any())
			{
				context.Cities.AddRange(
					new City() { Id = 1, Name = "Bursa", RegionId = 1 },
					new City() { Id = 2, Name = "Koceli", RegionId = 1 },
					new City() { Id = 3, Name = "Yalova", RegionId = 1 },
					new City() { Id = 4, Name = "Eskişehir", RegionId = 2 },
					new City() { Id = 5, Name = "Bilecik", RegionId = 2 },
					new City() { Id = 6, Name = "Kütahya", RegionId = 2 },
					new City() { Id = 7, Name = "Sakarya", RegionId = 2 },
					new City() { Id = 8, Name = "Konya", RegionId = 3 },
					new City() { Id = 9, Name = "Niğde", RegionId = 3 },
					new City() { Id = 10, Name = "Aksaray", RegionId = 3 },
					new City() { Id = 11, Name = "Karaman", RegionId = 3 },
					new City() { Id = 12, Name = "Adana", RegionId = 4 },
					new City() { Id = 13, Name = "Hatay", RegionId = 4 },
					new City() { Id = 14, Name = "Osmaniye", RegionId = 4 },
					new City() { Id = 15, Name = "Mersin", RegionId = 4 },
					new City() { Id = 16, Name = "Erzurum", RegionId = 5 },
					new City() { Id = 17, Name = "Ağrı", RegionId = 5 },
					new City() { Id = 18, Name = "Erzincan", RegionId = 5 }
					);
				context.SaveChanges();
			}

			if (!context.Users.Any())
			{
				byte[] passwordHash, passwordSalt;
				HashingHelper.CreatePasswordHash("Arif123.", out passwordHash, out passwordSalt);
				context.Users.AddRange(
					new User { Id = 1, FirstName = "Arif", LastName = "İskilip", Email = "arifiskilip@gmail.com", PhoneNumber = "05555555555", PasswordHash = passwordHash, PasswordSalt = passwordSalt },
					new User { Id = 2, FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@gmail.com", PhoneNumber = "05555555554", PasswordHash = passwordHash, PasswordSalt = passwordSalt }
					);
				context.SaveChanges();
			}
			if (!context.UnitTypes.Any())
			{
				context.UnitTypes.AddRange(
					new UnitType { Id=1, Name="Birim"},
					new UnitType { Id=2, Name="Adet"},
					new UnitType { Id=3, Name="Metre"},
					new UnitType { Id=4, Name="Parsel"}
					);
				context.SaveChanges();
			}
			if (!context.TaskTypes.Any())
			{
				context.TaskTypes.AddRange(
					new TaskType { Id =1,Name="Arşiv evrak ve paftaların ayrıştırılması, tasniflenmesi.....",UnitTypeId = (int)UnitTypeEnum.Adet},
					new TaskType { Id =2,Name="Evrakların taranması",UnitTypeId = (int)UnitTypeEnum.Adet},
					new TaskType { Id =3,Name="Pafta ve planların taranması (A0,A1,A2)",UnitTypeId = (int)UnitTypeEnum.Metre},
					new TaskType { Id =4,Name="Taranan pafta ve planların indeks....",UnitTypeId = (int)UnitTypeEnum.Parsel},
					new TaskType { Id =5,Name="Taranan A3, A4 VE A5 evrakların indexlenmesi",UnitTypeId = (int)UnitTypeEnum.Adet},
					new TaskType { Id =6,Name="Taranan A3, A4 VE A5 akıllandırarak EKBS.....",UnitTypeId = (int)UnitTypeEnum.Adet},
					new TaskType { Id =7,Name="Taranan pafta ve planların cetvellerinin indexlenmesi",UnitTypeId = (int)UnitTypeEnum.Parsel},
					new TaskType { Id =8,Name="Taranan pafta ve planların akıllandırarak EKBS.....",UnitTypeId = (int)UnitTypeEnum.Adet},
					new TaskType { Id =9,Name="Arşivin fiziksel düzenlenmesi ve klasörlerin değişimi",UnitTypeId = (int)UnitTypeEnum.Adet}
					);
				context.SaveChanges();
			}
			if (!context.Tasks.Any())
			{
				context.Tasks.AddRange(
					// 1. Bölge
					new Task { Id = 1, CityId=(int)CityEnum.Bursa,TaskTypeId=1,Total=1250},
					new Task { Id = 2, CityId=(int)CityEnum.Bursa,TaskTypeId=2,Total=1100},
					new Task { Id = 3, CityId=(int)CityEnum.Bursa,TaskTypeId=3,Total=3000},
					new Task { Id = 4, CityId=(int)CityEnum.Bursa,TaskTypeId=4,Total=60000},
					new Task { Id = 5, CityId=(int)CityEnum.Bursa,TaskTypeId=5,Total=1050},
					new Task { Id = 6, CityId=(int)CityEnum.Bursa,TaskTypeId=6,Total=1050},
					new Task { Id = 7, CityId=(int)CityEnum.Bursa,TaskTypeId=7,Total=60000},
					new Task { Id = 8, CityId=(int)CityEnum.Bursa,TaskTypeId=8,Total= 60000 },
					new Task { Id = 9, CityId=(int)CityEnum.Bursa,TaskTypeId=9,Total=6000},
					// 2. Bölge
					new Task { Id = 10, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 1, Total = 1150 },
					new Task { Id = 11, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 2, Total = 980 },
					new Task { Id = 12, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 3, Total = 18000 },
					new Task { Id = 13, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 4, Total = 80000 },
					new Task { Id = 14, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 5, Total = 980 },
					new Task { Id = 15, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 6, Total = 980 },
					new Task { Id = 16, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 7, Total = 80000 },
					new Task { Id = 17, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 8, Total = 80000 },
					new Task { Id = 18, CityId = (int)CityEnum.Eskisehir, TaskTypeId = 9, Total = 5070 },
					// 3. Bölge
					new Task { Id = 19, CityId = (int)CityEnum.Konya, TaskTypeId = 1, Total = 1150 },
					new Task { Id = 20, CityId = (int)CityEnum.Konya, TaskTypeId = 2, Total = 980 },
					new Task { Id = 21, CityId = (int)CityEnum.Konya, TaskTypeId = 3, Total = 18000 },
					new Task { Id = 22, CityId = (int)CityEnum.Konya, TaskTypeId = 4, Total = 80000 },
					new Task { Id = 23, CityId = (int)CityEnum.Konya, TaskTypeId = 5, Total = 980 },
					new Task { Id = 24, CityId = (int)CityEnum.Konya, TaskTypeId = 6, Total = 980 },
					new Task { Id = 25, CityId = (int)CityEnum.Konya, TaskTypeId = 7, Total = 80000 },
					new Task { Id = 26, CityId = (int)CityEnum.Konya, TaskTypeId = 8, Total = 80000 },
					new Task { Id = 27, CityId = (int)CityEnum.Konya, TaskTypeId = 9, Total = 5070 },
					// 4. Bölge
					new Task { Id = 28, CityId = (int)CityEnum.Adana, TaskTypeId = 1, Total = 1150 },
					new Task { Id = 29, CityId = (int)CityEnum.Adana, TaskTypeId = 2, Total = 980 },
					new Task { Id = 30, CityId = (int)CityEnum.Adana, TaskTypeId = 3, Total = 18000 },
					new Task { Id = 31, CityId = (int)CityEnum.Adana, TaskTypeId = 4, Total = 80000 },
					new Task { Id = 32, CityId = (int)CityEnum.Adana, TaskTypeId = 5, Total = 980 },
					new Task { Id = 33, CityId = (int)CityEnum.Adana, TaskTypeId = 6, Total = 980 },
					new Task { Id = 34, CityId = (int)CityEnum.Adana, TaskTypeId = 7, Total = 80000 },
					new Task { Id = 35, CityId = (int)CityEnum.Adana, TaskTypeId = 8, Total = 80000 },
					new Task { Id = 36, CityId = (int)CityEnum.Adana, TaskTypeId = 9, Total = 5070 },
					// 5. Bölge
					new Task { Id = 37, CityId = (int)CityEnum.Erzurum, TaskTypeId = 1, Total = 1150 },
					new Task { Id = 38, CityId = (int)CityEnum.Erzurum, TaskTypeId = 2, Total = 980 },
					new Task { Id = 39, CityId = (int)CityEnum.Erzurum, TaskTypeId = 3, Total = 18000 },
					new Task { Id = 40, CityId = (int)CityEnum.Erzurum, TaskTypeId = 4, Total = 80000 },
					new Task { Id = 41, CityId = (int)CityEnum.Erzurum, TaskTypeId = 5, Total = 980 },
					new Task { Id = 42, CityId = (int)CityEnum.Erzurum, TaskTypeId = 6, Total = 980 },
					new Task { Id = 43, CityId = (int)CityEnum.Erzurum, TaskTypeId = 7, Total = 80000 },
					new Task { Id = 44, CityId = (int)CityEnum.Erzurum, TaskTypeId = 8, Total = 80000 },
					new Task { Id = 45, CityId = (int)CityEnum.Erzurum, TaskTypeId = 9, Total = 5070 }
					);

				context.SaveChanges();
			}
		}
	}
}
