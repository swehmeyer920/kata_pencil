msbuild kata_pen.sln /t:Clean
msbuild kata_pen.sln /t:Clean /p:Configuration=Release
rmdir /s /q TestResults
del /q "kata_penTests\obj\Debug\*.*"
rmdir /s /q kata_pen\obj
rmdir /s /q kata_penTests\obj

