using System;
using _01._24;

await FetchNumbers.FetchNumbersFromAoC();
NumberManager manager = new NumberManager();
manager.TransferNumbersFromFileToLists();
manager.SortListItemsInAscendingOrder();
manager.SubtractSmallestNumbers();
manager.AddAllNumbers();