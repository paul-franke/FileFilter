# FileFilter
Filter out a series of consecutive lines

This program can be used to filter out a series of consecutive lines.
This text to be filtered is supplied via StdIn.
This text to be filtered out is read from a file.

Note: All white space is ignored

Sample: FilterFile -f filter.txt < FileToBeFiltered.txt.

Pre run contents:
FileToBeFiltered.txt               filter.txt

1
2 2                                 2 2
3 3  3                              3 3 3
4 4   4    4 


Post run contents:");
FileToBeFiltered.txt               filter.txt

1                                   2 2
4 4   4    4                        3 3 3

