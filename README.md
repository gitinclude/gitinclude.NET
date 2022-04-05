# gitinclude.NET
Use a .gitinclude to create or update a .gitignore file

EXPERIMENTAL: I started this as a nice little puzzle in response to a StackOverflow question.

## Downloads

- [Windows-X64](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/windows/ConsoleApp.exe)
- [Linux-X64](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/linux/ConsoleApp.exe)
- [OSX-X64](https://github.com/gitinclude/gitinclude.NET/raw/master/ConsoleApp/Executables/osx/ConsoleApp.exe)

## Notes

- A `.gitinclude` can be used aside of a `.gitignore` (it does not replace it). It updates a section of the `.gitignore` each time you run this app.
- A `.gitinclude` cannot affect the files in the root folder, so if you want those to be ignored, use the `.gitignore`.
- By default, everything is included, but if you define a `.gitinclude` rule, 
   1. everything in the base folder and its subfolders of that rule is excluded
   1. and the `.gitinclude` rules say what are the only files or file sets that should be included.
- Comments (starting with `#`) are ignored.