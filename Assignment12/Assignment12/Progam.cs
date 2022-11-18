
using ObserverPattern;

var author = new Assignment12.Author("AuthorName");

var reader1 = new Reader("Reader1");
var reader2 = new Reader("Reader2");
var reader3 = new Reader("Reader3");

author.AddFollower(reader1);
author.AddFollower(reader2);
author.AddFollower(reader3);

author.Publish(new Book("Title", "Description"));
