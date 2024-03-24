using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class TestService
    {
        private List<TestModel> list = new List<TestModel>();
        public TestService() 
        {
            for (int i = 0; i < 5; i++)
            {
                TestModel model = new TestModel();
                model.Id = Guid.NewGuid();
                model.Name = "vaibhav";
                model.Description = "person";
                list.Add(model);
            }
        }

        public TestModel ExecuteTest(TestModel model)
        {
            TestModel test = new TestModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };

            return test;
        }

        public List<TestModel> GetTests()
        {
            return list;
        }

        public TestModel GetModelById(string id)
        {
            TestModel model = list.FirstOrDefault(x => x.Id == Guid.Parse(id));
            return model;
        }

        public TestModel updateNameById(string id, string name)
        {
            TestModel model = list.FirstOrDefault(x => x.Id == Guid.Parse(id));
            model.Name = name;
            return model;
        }

        public List<TestModel> deleteById(string id)
        {
            TestModel model = list.FirstOrDefault(x => x.Id == Guid.Parse(id));
            list.Remove(model);
            return list;
        }
    }
}
