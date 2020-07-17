Kryptos4
========

An attempt at solving the fourth encrypted message in the [Kryptos][1] puzzle, using a Vigenère cypher and a lot of brute force.

Prerequisites
-------------

To build and run this application you'll need [.net core 3.1][2], which is available as a free download from Microsoft.

The application is a .net core console application written in C#. Compiled versions should work on Windows, Mac, and Linux.

Compiling
---------

Before compiling, it's a good idea to read through [Config.cs][3] to see if any configuration needs to be set. Comments in the file explain how everything works. I've tried to choose sensible defaults. At the very least it's a good idea to specify an output folder for results to be saved in.

To build the application:

    dotnet build

To run unit tests:

    dotnet test

To run the application:

    dotnet run

License
-------

This application is provided under the [MIT License][3]. Full text of the license is available in the [LICENSE.md][4] file of this repository.

[1]: https://en.wikipedia.org/wiki/Kryptos
[2]: https://dotnet.microsoft.com/download/dotnet-core
[3]: Config.cs
[4]: https://opensource.org/licenses/mit-license.php
[5]: LICENSE.md
