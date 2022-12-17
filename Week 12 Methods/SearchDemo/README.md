# Overview
This assignment exists to demonstrate my understanding of searches.
In my program, I do this by generating 10 random numbers, writing them to an array, then sorting the contents and searching for a randomly-chosen value. I then provide an in-code explanation of each.

## Linear Search
The linear search is the simplest of the search methods, as it merely cycles through the given collection until it finds its target value. One would think that the linear search's incredible simplicity would make it the quickest method, though this would be a false assumption; linear searching is often the slowest method, with the only exception being very small collections. Linear searches compensate for this by being universal, as they are the only search method which doesn't require a sorted collection.

The absolute worst-case runtime for a linear search is O(n).
The average runtime for a linear search is O(n/2).
The best-case runtime for a linear search is O(1).

## Binary Search
The binary search requires a sorted data set, making it less universal than a linear search. However, it is still powerful. The binary search starts by selecting the value in the middle of the collection. If this value is equal to the target value, the search is completed. If it is not, it compares the current value with the target value. If the target value is greater, it moves to the right side of its current position in the collection, otherwise it moves to the left. The binary search repeats this process indefinitely until it has located its target value.

The absolute worst-case runtime for a binary search is O(log2n).
The average runtime for a binary search is O(log2n).
The best-case runtime for a binary search is O(1).

## Interpolation Search
The interpolation search, like the binary search, requires a sorted collection. Additionally, that collection must be uniformly distributed. It is effectively a more efficient binary search, at the cost of requiring more setup. Whereas binary search starts in the middle of the collection every time, interpolation search starts in different locations based on the value being searched for. If the value is very close to the last item in the collection, interpolation search will start closer to the end of the collection. If it is closer to the beginning, interpolation will start near the beginning. This makes interpolation searches very swift and efficient, though, again, they require the most setup of the three primary search methods.

The absolute worst-case runtime for an interpolation search is O(n).
The average runtime for an interpolation search is O(log log N).
The best-case runtime for an interpolation search is O(log log N).
