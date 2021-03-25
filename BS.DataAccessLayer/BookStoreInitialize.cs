using BS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DataAccessLayer
{
    public class BookStoreInitialize : DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            List<User> listUsers = new List<User>() {
                new User(){UserName ="admin", Password="admin", Name = "Trần Văn Quang" ,  DateOfBirth = DateTime.Parse("09-22-1994"),Gender=1,PhoneNumber="0349655689",Email="tranquanghero@gmail.com",Address="Hà Nội",IsActive = true, Role=1},
                new User(){UserName ="user1", Password="user1", Name = "Trần Văn Quang" ,  DateOfBirth = DateTime.Parse("09-22-1994"),Gender=0,PhoneNumber="0349655689",Email="tranquanghero@gmail.com",Address="Hà Nội",IsActive = true, Role=0},
                new User(){UserName ="user2", Password="user2", Name = "Trần Văn Quang" ,  DateOfBirth = DateTime.Parse("09-22-1994"),Gender=0,PhoneNumber="0349655689",Email="tranquanghero@gmail.com",Address="Hà Nội",IsActive = true, Role=0},
                new User(){UserName ="user3", Password="user3", Name = "Trần Văn Quang" ,  DateOfBirth = DateTime.Parse("09-22-1994"),Gender=2,PhoneNumber="0349655689",Email="tranquanghero@gmail.com",Address="Hà Nội",IsActive = true, Role=0},
                new User(){UserName ="user4", Password="user4", Name = "Trần Văn Quang" ,  DateOfBirth = DateTime.Parse("09-22-1994"),Gender=2,PhoneNumber="0349655689",Email="tranquanghero@gmail.com",Address="Hà Nội",IsActive = true, Role=0}
            };
            context.Users.AddRange(listUsers);
            context.SaveChanges();



            List<Author> listAuthors = new List<Author>() {
                new Author(){Name="Trần Thanh Giao", BirthDate=DateTime.Parse("03-18-1974"),Address="Hà Nội",Introduction="Tiểu sử", Phone = "0123456789"},
                new Author(){Name="Thanh Hương", BirthDate=DateTime.Parse("02-13-1986"),Address="Bắc Giang",Introduction="Tiểu sử", Phone = "6898465165"},
                new Author(){Name="Sương Nguyệt Minh", BirthDate=DateTime.Parse("05-12-1929"),Address="Hà Nội",Introduction="Tiểu sử", Phone = "0123579965"},
                new Author(){Name="Nguyễn Khắc Mẫn", BirthDate=DateTime.Parse("02-28-1986"),Address="Hải Phòng",Introduction="Tiểu sử", Phone = "0986323698"},
                new Author(){Name="Nguyễn Khắc Phục", BirthDate=DateTime.Parse("04-17-1952"),Address="Thái Nguyên",Introduction="Tiểu sử", Phone = "0986596512"},
                new Author(){Name="Phạm Văn Đoan", BirthDate=DateTime.Parse("07-28-1945"),Address="Tuyên Quang",Introduction="Tiểu sử", Phone = "0912354789"},
                new Author(){Name="Phong Điệp", BirthDate=DateTime.Parse("02-13-1976"),Address="Nghệ Anh",Introduction="Tiểu sử", Phone = "0983657814"},
                new Author(){Name="Tạ Duy Anh", BirthDate=DateTime.Parse("04-17-1976"),Address="Hà Tĩnh",Introduction="Tiểu sử", Phone = "0123479521"},
                new Author(){Name="Trần Hữu Lục", BirthDate=DateTime.Parse("10-19-1983"),Address="Hải Phòng",Introduction="Tiểu sử", Phone = "0168593217"},
                new Author(){Name="Trần Phương Trà", BirthDate=DateTime.Parse("05-12-1954"),Address="Cao Bằng",Introduction="Tiểu sử", Phone = "0162397894"},
                new Author(){Name="Triệu Bôn", BirthDate=DateTime.Parse("02-16-1972"),Address="Hải Phòng",Introduction="Tiểu sử", Phone = "0324569821"},
                new Author(){Name="Võ Huy Tâm", BirthDate=DateTime.Parse("07-14-1956"),Address="Hà Nội",Introduction="Tiểu sử", Phone = "0123579965"},
                new Author(){Name="Xuân Mai", BirthDate=DateTime.Parse("04-12-1967"),Address="Hà Nội",Introduction="Tiểu sử", Phone = "5414465544"},
                new Author(){Name="Vũ Trọng Phụng", BirthDate=DateTime.Parse("07-11-1984"),Address="Hà Giang",Introduction="Tiểu sử", Phone = "0168379410"},
                new Author(){Name="Trần Quốc Toàn", BirthDate=DateTime.Parse("10-19-1965"),Address="Phú Thọ",Introduction="Tiểu sử", Phone = "0162354780"},
                new Author(){Name="Phan Quang", BirthDate=DateTime.Parse("04-28-1927"),Address="Hải Phòng",Introduction="Tiểu sử", Phone = "0162397894"},
                new Author(){Name="Nguyễn Trọng Tân", BirthDate=DateTime.Parse("02-19-1986"),Address="Hải Phòng",Introduction="Tiểu sử", Phone = "0123698745"},
                new Author(){Name="Phạm Thanh Quang", BirthDate=DateTime.Parse("05-09-1984"),Address="Hải Phòng",Introduction="Tiểu sử", Phone = "0649632587"},
                new Author(){Name="Nguyễn Thị Thu Huệ", BirthDate=DateTime.Parse("10-19-1965"),Address="Bắc Giang",Introduction="Tiểu sử", Phone = "0168657952"},
                new Author(){Name="Nhất Linh", BirthDate=DateTime.Parse("07-21-1927"),Address="Bắc Giang",Introduction="Tiểu sử", Phone = "0123589315"},
                new Author(){Name="Phạm Việt Long", BirthDate=DateTime.Parse("05-22-1984"),Address="Bắc Giang",Introduction="Tiểu sử", Phone = "01275239752"},
                new Author(){Name="Phú Đức", BirthDate=DateTime.Parse("05-23-1927"),Address="Cao Bằng",Introduction="Tiểu sử", Phone = "0923648954"},
                new Author(){Name="Trầm Hương", BirthDate=DateTime.Parse("02-07-1984"),Address="Bắc Ninh",Introduction="Tiểu sử", Phone = "0324569821"},
                new Author(){Name="Trúc Phương", BirthDate=DateTime.Parse("07-08-1927"),Address="Thái Nguyên",Introduction="Tiểu sử", Phone = "0123485698"},
                new Author(){Name="Trương Vĩnh Ký", BirthDate=DateTime.Parse("02-06-1965"),Address="Thái Nguyên",Introduction="Tiểu sử", Phone = "0128667892"}
            };
            context.Authors.AddRange(listAuthors);
            context.SaveChanges();

            List<Publisher> listPublishers = new List<Publisher>() {
                new Publisher(){Name="Nhà xuất bản Kim Đồng", Introduction="Đây là nhà xuất bản sách nổi tiếng cho thiếu nhi thuộc trực thuộc Trung ương Đoàn TNCS Hồ Chí Minh. Các nhà văn trẻ có thể gửi tác phẩm của mình cho nhà xuất bản Kim Đồng. Nhà xuất bản Kim Đồng chuyên in ấn, xuất bản sách dành cho thiếu nhi và các bậc phụ huynh trong cả nước. Ngoài ra nhà xuất bản còn có nhiều sách để quảng bá và giới thiệu văn hóa Việt Nam ra thế giới.", Address="55 Quang Trung, Hai Bà Trưng, Hà Nội", Phone = "02439434730"},
                new Publisher(){Name="Nhà xuất bản Trẻ", Introduction="Nhà xuất bản trẻ xuất bản sách và văn hóa phẩm các loại, phục vụ chủ yếu là các đối tượng trẻ như thanh niên, thiếu nhi, tổ chức Đoàn các cấp của thành phố, phục vụ bạn đọc trong và ngoài nước. Nhà xuất bản có nhận xuất bản nhiều thể loại sách như: tài liệu chính trị, kiến thức phổ thông, văn hóa – xã hội, nghệ thuật, văn học, từ điển,...", Address="161B Lý Chính Thắng, Phường 7, Quận 3, Thành phố Hồ Chí Minh", Phone = "(028) 39316289"},
                new Publisher(){Name="Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh", Introduction="Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh được thành lập từ năm 1977. Đúng như tên gọi của nhà xuất bản là cơ quan hội tụ về tư tưởng, văn hóa, chính trị của Đảng bộ và nhân dân thành phố", Address="62 Nguyễn Thị Minh Khai, Phường Đa Kao, Quận 1, TP.HCM", Phone = "(028) 38 225 340"},
                new Publisher(){Name="Nhà xuất bản chính trị quốc gia", Introduction="Nhà xuất bản Chính trị quốc gia là đơn vị sự nghiệp trung ương của Đảng, xuất bản những cuốn sách về chính trị của Đảng và Nhà nước. Tổ chức biên tập, xuất bản các sách chính trị, xã hội, lý luận và pháp luật. Nhà xuất bản xuất bản sách chính trị nhằm nâng cao các kiến thức của nhân dân về chính trị, xã hội, lý luận và pháp luật. Phục vụ sự nghiệp đổi mới và hai nhiệm vụ chiến lược xây dựng và bảo vệ Tổ quốc.", Address="Số 6/86 Duy Tân, Cầu Giấy, Hà Nội", Phone = "0280.49221"},
                new Publisher(){Name="Nhà xuất bản giáo dục", Introduction="Nhà xuất bản Giáo dục được thành lập ngày 1 tháng 6 năm 1957. Nhà xuất bản là một doanh nghiệp Nhà nước trực thuộc Bộ Giáo dục và Đào tạo", Address="81 Trần Hưng Đạo, Hà Nội", Phone = "024.38220801"},
                new Publisher(){Name="Nhà xuất bản Hội Nhà văn", Introduction="Nhà xuất bản Hội Nhà văn được thành lập năm 1957. Nhà xuất bản Hội Nhà văn là sự kế thừa và tiếp thu có hiệu quả của công tác xuất bản của Nhà xuất bản Văn nghệ. Sản phẩm chủ yếu của nhà xuất bản là xuất bản sách đa dạng các thể loại như: tiểu thuyết, văn học, truyện ngắn, nghiên cứu, thơ,… và báo chí.", Address="Số 65 Nguyễn Du, Hà Nội", Phone = "024.38222135"},
                new Publisher(){Name="Nhà xuất bản Tư pháp", Introduction="Nhà xuất bản Tư pháp là đơn vị sự nghiệp trực thuộc Bộ Tư pháp, nhà xuất bản có nhiệm vụ xuất bản ra sách có những nội dung nhằm mục đích Tuyên truyền chủ trương các chính sách của Đảng, pháp luật của Nhà nước về ngành Tư pháp.. Xây dựng Nhà nước pháp quyền xã hội chủ nghĩa Việt Nam.", Address="Số 35 Trần Quốc Toản, Hoàn Kiếm, Hà Nội", Phone = "024.62632078"},
                new Publisher(){Name="Nhà xuất bản thông tin và truyền thông", Introduction="Nhà xuất bản là tổ chức trực thuộc Bộ Thông tin và Truyền Thông, có nhiệm vụ thực hiện chức năng xuất bản sách phục vụ cho công tác quản lý nhà nước về: Tài liệu chính trị, pháp luật, xã hội, văn hóa xã hội, nghệ thuật, lịch sử truyền thống, địa lí,…Và đặc biệt là các nhiệm vụ khác do Bộ Thông tin và Truyền thông giao phó.", Address="Tầng 6, Tòa nhà Cục Tần số Vô tuyến điện, số 115 Trần Duy Hưng, Hà Nội", Phone = "024 35772145"},
                new Publisher(){Name="Nhà xuất bản lao động", Introduction="Nhà xuất bản chuyên in sách về nhiệm vụ tổ chức bản thảo, biên tập và phát hành sách về các lĩnh vực liên quan đến quân đội", Address="175 Giảng Võ, Đống Đa, Hà Nội", Phone = "0243.8515380"},
                new Publisher(){Name="Nhà xuất bản giao thông vận tải", Introduction="Đúng như tên gọi của nó. Đây là nhà xuất bản duy nhất chuyên trong lĩnh vực giao thông vận tải. Sau hơn 30 năm xây dựng và phát triển, nhà xuất bản đã trở thành một thương hiệu trong ngành Xuất bản ngành này tại Việt Nam", Address="80B Trần Hưng Đạo, Hoàn Kiếm, Hà Nội", Phone = " 024 3.9423346"},
                new Publisher(){Name="Nhà xuất bản Nhã Nam", Introduction="Nhã Nam được đánh giá là một trong những nhà xuất bản tư nhân uy tín nhất tại Việt Nam hiện nay. Được thành lập vào tháng 2 năm 2005, tuy nhiên sự chuẩn bị đã đến từ trước đó, với một nhóm bạn bè yêu thích văn chương và quý trọng sách vở thì Balzac và cô bé thợ may Trung hoa của Đới Tư Kiệt chính là cuốn sách đầu tiên được những người sáng lập Nhã Nam xuất bản ngay cả trước khi công ty ra đời. Ngay lập tức từ cuốn sách đầu tiên này, độc giả đã dành sự quan tâm và yêu mến cho một thương hiệu sách mới mẻ mang trong mình niềm khát vọng góp phần tạo lập diện mạo mới cho xuất bản văn học tại Việt Nam.", Address="59 Đỗ Quang, KĐT Trung Hòa Nhân Chính, Cầu Giấy, Hà Nội", Phone = "(84-4) 35 146 876"},
                new Publisher(){Name="Nhà xuất bản Thái Hà Books", Introduction="Thái Hà Books hiện đang được đánh giá là doanh nghiệp số 1 tại Việt Nam về sách nuôi dạy trẻ thông minh sớm, số 1 Việt Nam về thể loại sách Light Novel và là công ty sách hàng đầu chuyên xuất bản sách Phật giáo và tâm linh đồng thời cũng là một trong 3 công ty mạnh nhất Việt Nam về dòng sách kinh tế.", Address="53 Phạm Thận Duật, P. Mai Dịch, Cầu Giấy, Hà Nội", Phone = "043 7930480 "},
                new Publisher(){Name="Nhà xuất bản Phương Nam Book", Introduction="Công ty Sách Phương Nam, tiền thân là Trung tâm Sách & Dịch vụ Bản quyền Phương Nam, là một công ty thành viên của Phương Nam Corp. Với chủ trương Sách hay cho mọi người, Phương Nam Book vẫn đã và đang liên tục xuất bản những đầu sách bán chạy nhằm đáp ứng nhu cần căn bản là tìm hiểu và giải trí của đông đảo người yêu sách.", Address="496 Nguyễn Thị Minh Khai, P.2, Q.3, Tp. Hồ Chí Minh", Phone = "(08) 3832 1849"},
                new Publisher(){Name="Nhà xuất bản Đông A Book", Introduction="Được thành lập từ tháng 11/ 2004, Đông A được đánh giá là một trong những công ty tư nhân đầu tiên hoạt động trong lĩnh vực xuất bản và phát hành. Từ một công ty chỉ gồm 6 người, sau hơn 5 năm hoạt động thì công ty đã xây dựng được đội ngũ với gần 40 nhân viên làm việc tại Hà Nội và TP. Hồ Chí Minh cùng hàng trăm cộng tác viên là những nhà văn, dịch giả và biên tập viên uy tín trên cả nước.", Address="113 Đông Các, P. Ô Chợ Dừa, Q. Đống Đa, Hà Nội", Phone = "(84-4) 3856 9367"},
                new Publisher(){Name="Nhà xuất bản Alpha Books", Introduction="Công ty cổ phần Sách Alpha do một nhóm trí thức trẻ thành lập ở Hà Nội vào năm 2005 với niềm tin: Tri thức là Sức mạnh. Thông qua việc giới thiệu các tác phẩm có giá trị của thế giới, Alpha Books mong muốn sẽ trở thành nhịp cầu nối nguồn tri thức nhân loại với dân tộc Việt Nam. Trong bối cảnh Việt Nam gia nhập WTO, thực thi Luật Xuất bản mới và Công ước Berne về bản quyền có hiệu lực, Alpha Books đặt mục tiêu mua bản quyền và xuất bản những đầu sách có giá trị nhằm đáp ứng nhu cầu của độc giả Việt Nam. ", Address="176 Thái Hà, Đống Đa, Hà Nội  ", Phone = "(84-4) 3722 6234"},
                new Publisher(){Name="Nhà xuất bản First New", Introduction="Khác biệt tạo nên sự tồn tại, đây được coi là bí quyết của các công ty sách tư nhân tìm lối đi riêng trên thị trường xuất bản. Dù cho hoạt động xuất bản đang gặp khó khăn, tình trạng sách bị in lậu diễn ra một cách thường xuyên, thế nhưng mua bản quyền sách chính là cách mà First New đi tiên phong và thu được thành công lớn. First News luôn năng động và tích cực để tìm thông tin, tài liệu từ nước ngoài, rồi liên hệ với các nhà xuất bản, các Tập đoàn xuất bản trên thế giới để có thể thương lượng bản quyền xuất bản.", Address="11H Nguyễn Thị Minh Khai, Quận 1, Tp. Hồ CHí Minh", Phone = "0123456789"},
                new Publisher(){Name="Nhà xuất bản Đông Tây", Introduction="Công ty TNHH Văn hóa Đông Tây, trực thuộc Trung tâm văn hóa ngôn ngữ Đông Tây được thành lập từ năm 1999. Khi ra đời, Đông Tây chỉ là một nhà sách nhỏ, hoạt động chính là bán lẻ sách, báo…. Thế nhưng cho đến hôm nay trước sự phát triển chung, Đông Tây đã xây dựng được riêng cho mình một thương hiệu với triết lý kinh doanh xuyên suốt từ những ngày đầu thành lập là: luôn cố gắng gìn giữ văn hóa đọc, đem tri thức đến với mọi thế hệ người Việt, để tri thức len lỏi trong từng xóm làng Việt Nam", Address="Không gian văn hóa Đông Tây, làng sinh viên Hacinco, 99 Ngụy Như Kon Tum, Thanh Xuân, Hà Nội", Phone = "04 2215 4411"},
                //17
            };
            context.Publishers.AddRange(listPublishers);
            context.SaveChanges();



            List<Category> listCategories = new List<Category>() {
                new Category(){Name="Công nghệ thông tin",Description="Mô tả về Công nghệ thông tin"},
                new Category(){Name="Ngoại ngữ",Description="Mô tả về Ngoại ngữ"},
                new Category(){Name="Phật Giáo",Description="Mô tả về Phật Giáo"},
                new Category(){Name="Sách học làm người",Description="Mô tả về Sách học làm người"},
                new Category(){Name="Văn học nước ngoài",Description="Mô tả về Văn học nước ngoài"},
                new Category(){Name="Kinh Tế",Description="Mô tả về Kinh Tế"},
                new Category(){Name="Khoa học Vật lý",Description="Mô tả về Khoa học Vật lý"},
                new Category(){Name="Khoa học Xã hội",Description="Mô tả về Khoa học Xã hội"},
                new Category(){Name="Luật",Description="Mô tả về Luật"},
                new Category(){Name="Lịch sử, địa lý",Description="Mô tả về Lịch sử, địa lý"},
                new Category(){Name="Mỹ thuật",Description="Mô tả về Mỹ thuật"},
                new Category(){Name="Nghệ thuật",Description="Mô tả về Nghệ thuật"},
                new Category(){Name="Âm nhạc",Description="Mô tả về Âm nhạc"},
                new Category(){Name="Sách tham khảo",Description="Mô tả về Sách tham khảo"},
                new Category(){Name="Danh nhân",Description="Mô tả về Danh nhân"},
                new Category(){Name="Tâm lý giáo dục",Description="Mô tả về Tâm lý giáo dục"},
                new Category(){Name="Thể thao - Võ thuật",Description="Mô tả về Thể thao - Võ thuật"},
                new Category(){Name="Văn hóa - Xã hội",Description="Mô tả về Văn hóa - Xã hội"},
                new Category(){Name="Nghệ thuật làm đẹp",Description="Mô tả về Nghệ thuật làm đẹp"},
                new Category(){Name="Du lịch",Description="Mô tả về Du lịch"},
                new Category(){Name="Y Học dân tộc vn",Description="Mô tả về Y Học dân tộc vn"},
                //21
            };
            context.Categories.AddRange(listCategories);
            context.SaveChanges();

            List<Book> books = new List<Book>() {
                new Book(){Title="Sketchup & Vray Trong Thiết Kế 1 Kiến Trúc" , Price=55000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="1.jpg" ,Stock=10, CategoryId=1, PublisherId=1, AuthorId =1, IsNew=true},
                new Book(){Title="3DS Max-Thủ Thuật Render Phối Cảnh kiến Trúc Ban Ngày Và Đêm Với V-Ray 1.50 RC3" , Price=63000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="2.jpg" ,Stock=10, CategoryId=2, PublisherId=2,AuthorId =2, IsNew=false},
                new Book(){Title="Tự Học InDesign CS3" , Price=70500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="3.jpg" ,Stock=10, CategoryId=3, PublisherId=3, AuthorId =3,IsNew=true},
                new Book(){Title="Đắc Nhân Tâm - Cuốn Sách Hay Nhất Của Mọi Thời Đại Đưa Bạn Đến Thành Công!" , Price=68000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="4.jpg" ,Stock=10, CategoryId=4, PublisherId=4, AuthorId =4,IsNew=true},
                new Book(){Title="Tự Học Photoshop CS5 Qua Hình Ảnh Minh Họa (Sách Kèm CD)" , Price=10500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="5.jpg" ,Stock=10, CategoryId=5, PublisherId=5, AuthorId =5,IsNew=true},
                new Book(){Title="180 Thủ Thuật Và Mẹo Hay Trong Flash CS4" , Price=21500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="6.jpg" ,Stock=10, CategoryId=6, PublisherId=6, AuthorId =6,IsNew=true},
                new Book(){Title="Microsoft Office 2010 - Dành Cho Người Tự Học" , Price=78600,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="7.jpg" ,Stock=10, CategoryId=7, PublisherId=7, AuthorId =7,IsNew=false},
                new Book(){Title="Tự học Microsoft Excel 2010" , Price=82000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="8.jpg" ,Stock=10, CategoryId=3, PublisherId=8,AuthorId =8, IsNew=true},
                new Book(){Title="C# Dành Cho Người Tự Học - Tập 1" , Price=47000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="9.jpg" ,Stock=10, CategoryId=9, PublisherId=9,AuthorId =9, IsNew=true},
                new Book(){Title="C# Dành Cho Người Tự Học - Tập 2" , Price=12000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="10.jpg" ,Stock=10, CategoryId=10, PublisherId=10, AuthorId =10,IsNew=true},
                new Book(){Title="Nghệ Thuật Sống An Lạc " , Price=36000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="11.jpg" ,Stock=10, CategoryId=11, PublisherId=11,AuthorId =11, IsNew=true},
                new Book(){Title="Phương Pháp Quản Lý Nhân Sự Trong Công Ty" , Price=47500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="12.jpg" ,Stock=10, CategoryId=12, PublisherId=12,AuthorId =12, IsNew=false},
                new Book(){Title="Ngọc Sáng Trong Hoa Sen" , Price=63250,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="13.jpg" ,Stock=10, CategoryId=13, PublisherId=13,AuthorId =13, IsNew=true},
                new Book(){Title="Hành Trình Về Phương Đông" , Price=78600,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="14.jpg" ,Stock=10, CategoryId=14, PublisherId=14, AuthorId =14,IsNew=true},
                new Book(){Title="Lập Bản Đồ Tư Duy - Công Cụ Tư Duy Tối Ưu Sẽ Làm Thay Đổi Cuộc Sống Của Bạn" , Price=80000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="15.jpg" ,Stock=10, CategoryId=15, PublisherId=15,AuthorId =15, IsNew=false},
                new Book(){Title="Đơn Giản Và Thuần Khiết" , Price=27800,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="16.jpg" ,Stock=10, CategoryId=16, PublisherId=16,AuthorId =16, IsNew=true},
                new Book(){Title="Cách Sống - Từ Bình Thường Trở Nên Phi Thường" , Price=64720,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="17.jpg" ,Stock=10, CategoryId=17, PublisherId=17, AuthorId =17,IsNew=true},
                new Book(){Title="Những Quy Luật Mới Trong Bán Lẻ" , Price=78200,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="18.jpg" ,Stock=10, CategoryId=18, PublisherId=1, AuthorId =18,IsNew=true},
                new Book(){Title="Lavina Và Hầu Tước Elswick (Cuộc Chạy Trốn Nữ Hoàng)" , Price=31500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="19.jpg" ,Stock=10, CategoryId=19, PublisherId=1, AuthorId =19,IsNew=true},
                new Book(){Title="Hành Vi Tổ Chức - Organizational Behavior" , Price=42500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="20.jpg" ,Stock=10, CategoryId=20, PublisherId=2,AuthorId =20, IsNew=false},
                new Book(){Title="17 Nguyên Tắc Vàng Trong Làm Việc Nhóm" , Price=56000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="21.jpg" ,Stock=10, CategoryId=21, PublisherId=3,AuthorId =21, IsNew=true},
                new Book(){Title="Essential Words For The IELTS (Kèm 1 Đĩa CD)" , Price=51240,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="22.jpg" ,Stock=10, CategoryId=1, PublisherId=4,AuthorId =22, IsNew=false},
                new Book(){Title="Tiếng Hàn Trong Giao Tiếp Hàng Ngày" , Price=60300,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="23.jpg" ,Stock=10, CategoryId=2, PublisherId=5, AuthorId =23,IsNew=false},
                new Book(){Title="80 Chiêu Thức Kinh Doanh Thành Công" , Price=27800,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="24.jpg" ,Stock=10, CategoryId=3, PublisherId=6, AuthorId =24,IsNew=true},
                new Book(){Title="Những Công Cụ Thiết Yếu Trong Phân Tích Kỹ Thuật Thị Trường Tài Chính " , Price=10200,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="25.jpg" ,Stock=10, CategoryId=4, PublisherId=7, AuthorId =25,IsNew=true},
                new Book(){Title="Nàng Lọ Lem Và Đàn Chuột Mất Tích" , Price=32000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="26.jpg" ,Stock=10, CategoryId=5, PublisherId=8,AuthorId =1, IsNew=true},
                new Book(){Title="Công Chúa Aurora Và Chú Rồng Nhỏ" , Price=45600,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="27.jpg" ,Stock=10, CategoryId=6, PublisherId=9,AuthorId =2, IsNew=true},
                new Book(){Title="3ds Max 2009 " , Price=47500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="28.jpg" ,Stock=10, CategoryId=7, PublisherId=10, AuthorId =3,IsNew=true},
                new Book(){Title="Công Nghệ Mạng Máy Tính" , Price=63000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="29.jpg" ,Stock=10, CategoryId=8, PublisherId=11,AuthorId =4, IsNew=true},
                new Book(){Title="Tính Toán Thiết Kế Kết Cấu Với SAP 14" , Price=12350,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="30.jpg" ,Stock=10, CategoryId=9, PublisherId=12,AuthorId =5, IsNew=true},
                new Book(){Title="Revit Architecture 2011 Từ A Đến Z - Tập 2" , Price=47000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="31.jpg" ,Stock=10, CategoryId=10, PublisherId=13,AuthorId =6, IsNew=true},
                new Book(){Title="CoreIDraw X5 - Dành Cho Người Tự Học" , Price=52300,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="32.jpg" ,Stock=10, CategoryId=11, PublisherId=14,AuthorId =7, IsNew=true},
                new Book(){Title="Chế Bản Điện Tử Với Ilustrator CS5" , Price=82300,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="33.jpg" ,Stock=10, CategoryId=12, PublisherId=15, AuthorId =8,IsNew=true},
                new Book(){Title="Cẩm Nang Tin Học Văn Phòng" , Price=97000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="34.jpg" ,Stock=10, CategoryId=13, PublisherId=16, AuthorId =9,IsNew=true},
                new Book(){Title="Xử Lý Ảnh Photoshop CS5 Dành Cho Người Tự Học - Tập 1" , Price=91000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="35.jpg" ,Stock=10, CategoryId=14, PublisherId=17,AuthorId =10, IsNew=true},
                new Book(){Title="71 Kỹ Thuật Thâm Nhập Windows Vista Pro" , Price=51200,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="36.jpg" ,Stock=10, CategoryId=15, PublisherId=1, AuthorId =11,IsNew=false},
                new Book(){Title="Hướng Dẫn Học Từng Bước Excel 2010 Dành Cho Người Tự Học" , Price=53000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="37.jpg" ,Stock=10, CategoryId=16, PublisherId=2,AuthorId =12, IsNew=true},
                new Book(){Title="SQL Server 2005 - Xây Dựng Ứng Dụng Quản Lý Kế Toán Bằng C# 2005 " , Price=17350,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="38.jpg" ,Stock=10, CategoryId=17, PublisherId=3,AuthorId =13, IsNew=true},
                new Book(){Title="Lập Trình Web Bằng ASP.Net Với Macromedia Dreamweaver MX - Tập 2" , Price=19000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="39.jpg" ,Stock=10, CategoryId=18, PublisherId=4,AuthorId =14, IsNew=false},
                new Book(){Title="Tạo Website Hướng Database Bằng PHP Và MYSQL - Tập 2" , Price=20600,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="40.jpg" ,Stock=10, CategoryId=19, PublisherId=5,AuthorId =15, IsNew=true},
                new Book(){Title="Tạo Bản Thuyết Trình Trong Microsoft Office PowerPoint 2007 For Windows" , Price=31500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="41.jpg" ,Stock=10, CategoryId=20, PublisherId=6, AuthorId =16,IsNew=false},
                new Book(){Title="Shambhala - Vùng Đất Tây Tạng Huyền Bí Hay Cuộc Hành Trình Tìm Về Bản Thể" , Price=37800,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="42.jpg" ,Stock=10, CategoryId=21, PublisherId=7, AuthorId =17,IsNew=true},
                new Book(){Title="Sức Mạnh Của Đạo Phật - Để Sống Tốt Hơn Trong Thế Giới Ngày Nay" , Price=42800,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="43.jpg" ,Stock=10, CategoryId=1, PublisherId=8,AuthorId =18, IsNew=true},
                new Book(){Title="Điều Trị Bệnh Tận Gốc - Năng Lực Của Tâm Bi Mẫn " , Price=63000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="44.jpg" ,Stock=10, CategoryId=2, PublisherId=9, AuthorId =19,IsNew=false},
                new Book(){Title="Nhập Môn Windows Vista Tập 1" , Price=58000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="45.jpg" ,Stock=10, CategoryId=3, PublisherId=10, AuthorId =20,IsNew=true},
                new Book(){Title="Hành Trình Tâm Linh Siêu Việt" , Price=75000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="46.jpg" ,Stock=10, CategoryId=4, PublisherId=11,AuthorId =21, IsNew=true},
                new Book(){Title="Nghiệp Lực - Nhìn Lại Quá Khứ & Nhận Biết Tương Lai" , Price=64000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="47.jpg" ,Stock=10, CategoryId=5, PublisherId=12, AuthorId =22,IsNew=false},
                new Book(){Title="Tỉnh Thức" , Price=39000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="48.jpg" ,Stock=10, CategoryId=6, PublisherId=13, AuthorId =23,IsNew=true},
                new Book(){Title="13 Nguyên Tắc Nghĩ Giàu, Làm Giàu - Think And Grow Rich" , Price=90000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="49.jpg" ,Stock=10, CategoryId=7, PublisherId=14,AuthorId =24, IsNew=true},
                new Book(){Title="Đạo Kỷ Nguyên Mới" , Price=78000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="50.jpg" ,Stock=10, CategoryId=8, PublisherId=15,AuthorId =25, IsNew=true},
                new Book(){Title="The Power Of Compassion - Sức mạnh của lòng từ" , Price=83500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="51.jpg" ,Stock=10, CategoryId=9, PublisherId=16,AuthorId =1, IsNew=true},
                new Book(){Title="Con Đường Mây Trắng - DER WEG DER WEISSEN WOLKEN" , Price=96000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="52.jpg" ,Stock=10, CategoryId=10, PublisherId=17, AuthorId =2,IsNew=true},
                new Book(){Title="Con đường mưa" , Price=67000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="53.jpg" ,Stock=10, CategoryId=11, PublisherId=1,AuthorId =3, IsNew=true},
                new Book(){Title="Đức Đạt Lai Lạt Ma Tại Harvard" , Price=72500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="54.jpg" ,Stock=10, CategoryId=12, PublisherId=2,AuthorId =4, IsNew=true},
                new Book(){Title="Những Con Đường Của Ánh Sáng - Tập 1" , Price=64300,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="55.jpg" ,Stock=10, CategoryId=13, PublisherId=3, AuthorId =5,IsNew=false},
                new Book(){Title="Những Con Đường Của Ánh Sáng - Tập 2" , Price=59000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="56.jpg" ,Stock=10, CategoryId=14, PublisherId=4,AuthorId =6, IsNew=true},
                new Book(){Title="Cái Vô Hạn Trong Lòng Bàn Tay (Từ Big Bang Đến Giác Ngộ)" , Price=63500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="57.jpg" ,Stock=10, CategoryId=15, PublisherId=5, AuthorId =7,IsNew=false},
                new Book(){Title="Nghệ Thuật Thiền Định" , Price=82000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="58.jpg" ,Stock=10, CategoryId=16, PublisherId=6, AuthorId =8,IsNew=true},
                new Book(){Title="Bàn Về Hạnh Phúc" , Price=17000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="59.jpg" ,Stock=10, CategoryId=17, PublisherId=7, AuthorId =9,IsNew=true},
                new Book(){Title="Lượng tử hoa và sen" , Price=52000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="60.jpg" ,Stock=10, CategoryId=18, PublisherId=8, AuthorId =10,IsNew=true},
                new Book(){Title="Đối Thoại Giữa Triết Học Và Phật Giáo" , Price=63000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="61.jpg" ,Stock=10, CategoryId=19, PublisherId=9,AuthorId =11, IsNew=true},
                new Book(){Title="Phật giáo truyền thống Đại Thừa" , Price=74000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="62.jpg" ,Stock=10, CategoryId=20, PublisherId=10, AuthorId =12,IsNew=true},
                new Book(){Title="Tình Yêu Phổ Quát" , Price=69000,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="63.jpg" ,Stock=10, CategoryId=21, PublisherId=11, AuthorId =13,IsNew=true},
                new Book(){Title="Tôi tài giỏi bạn cũng thế" , Price=57600,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="64.jpg" ,Stock=10, CategoryId=1, PublisherId=12, AuthorId =14,IsNew=true},
                new Book(){Title="Rộng Mở Tâm Hồn - Tu Tập Từ Bi Trong Đời Sống Hàng Ngày" , Price=20500,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="65.jpg" ,Stock=10, CategoryId=2, PublisherId=13,AuthorId =15, IsNew=true},
                new Book(){Title="Cuộc Đời Là Vô Thường" , Price=68300,Description ="Mota",DateOfUpdate=DateTime.Parse("08-09-2017"),Image="66.jpg" ,Stock=10, CategoryId=3, PublisherId=14,AuthorId =16, IsNew=true}
            };
            context.Books.AddRange(books);
            context.SaveChanges();





            context.SaveChanges();




            base.Seed(context);
        }


    }
}
