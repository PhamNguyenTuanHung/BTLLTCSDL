using System.Collections.Generic;

namespace DOT
{
    public interface IThucThe
    {
        string LayTenThucThe(); // Lấy tên thực thể (Sinh viên, Giáo viên...)
        Dictionary<string, object> LayDuLieuThucThe(); // Trả về danh sách thông tin dưới dạng key-value
    }

}
