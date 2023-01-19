using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCBlog.UI.TagHelpers;


[HtmlTargetElement("a", Attributes = "del", ParentTag = "td")]
public class DeleteTagHelper : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        string btn = "<a class='btn btn-sm  shadow-sm'>  <i class='fa  fa-trash text-danger'></i> </a>";
        output.TagName = "a";
        output.Content.SetHtmlContent(btn);

        return base.ProcessAsync(context, output);
    }
}

















[HtmlTargetElement("a", Attributes = "search", ParentTag = "td")]
public class SearchTagHelper : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        string btn = "<a class='btn btn-sm  shadow-sm'>  <i class='fa  fa-search text-primary'></i> </a>";
        output.TagName = "a";
        output.Content.SetHtmlContent(btn);


        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("a", Attributes = "edit", ParentTag = "td")]
public class EditTagHelper : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        string btn = "<a class='btn btn-sm  shadow-sm'>  <i class='fa  fa-pencil text-warning'></i> </a>";
        output.TagName = "a";
        output.Content.SetHtmlContent(btn);


        return base.ProcessAsync(context, output);
    }
}