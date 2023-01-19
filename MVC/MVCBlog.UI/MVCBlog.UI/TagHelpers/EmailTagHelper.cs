using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCBlog.UI.TagHelpers;

public class EmailTagHelper : TagHelper
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {

        string address = $"mailto: {FirstName}.{LastName}@code.edu.az".ToLower();
        output.TagName = "a";    // Replaces <email> with <a> tag
        output.Attributes.SetAttribute("href", address);
        output.Content.SetContent(address);
    }
}
public class Deneme : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";    // Replaces <email> with <a> tag
    }
}
public class Denemedim : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "table";    // Replaces <email> with <a> tag
    }
}
