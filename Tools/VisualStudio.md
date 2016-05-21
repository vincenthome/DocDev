#Visual Studio

##Bootstrap Snippets

- https://github.com/elebetsamer/bootstrap-snippets-visual-studio

## Snippets Create / Import
How to create/import snippets and Collection of snippets

[Walkthrough: Creating a Code Snippet](https://msdn.microsoft.com/en-us/library/ms165394.aspx)

###Snippet Template - Save As xyz.snippet
Edit Title, Shortcut and CDATA

```
Edit Title, Shortcut and CDATA
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets
    xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
        <Header>
            <Author>Vincent Leung</Author>
            <Title>New Snippet 1</Title>
            <Shortcut>helloworld1</Shortcut>
        </Header>
        <Snippet>
            <Code Language="CSharp">
                <![CDATA[
                // Your C# code follows:

                ]]>
            </Code>
        </Snippet>
    </CodeSnippet>
</CodeSnippets>
```

##Import to Visual Studio

1. Tools/Code Snippets Manager
2. Click Import
3. Select source xyz.snippet file
4. Select target snippet location - 'My Code Snippets' 
