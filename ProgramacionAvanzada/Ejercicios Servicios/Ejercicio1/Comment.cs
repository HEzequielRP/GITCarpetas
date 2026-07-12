using System;
using System.Net.Http.Json;
using System.Text.Json;

namespace Ejercicio1;
public class Comment
{
    public int id { get; set; }
    public int postId { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string body { get; set; }
}