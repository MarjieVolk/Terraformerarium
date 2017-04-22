### Ecosystem Representation
* An ecosystem hasa multiset of produced resources.
* An ecosystem hasa multiset of consumed resources.
* An ecosystem hasa multiset of required resources.
* An ecosystem hasa multiset of organisms.
* An ecosystem hasa humidity level.
* An ecosystem hasa soil richness.
* An ecosystem hasa temperature.

### Organism Representation
* An organism hasa multiset of produced resources.
* An organism hasa multiset of consumed resources.
* An organism hasa multiset of required resources.
* An organism hasa effect on humidity / soil richness / temperature.
* An organism hasa minimum and maximum humidity level.
* An organism hasa minimum and maximum soil richness.
* An organism hasa minimum and maximum temperature.

### Stuffs
* An ecosystem's produced resources are the multiset union of the produced resources of each organism.
* An ecosystem's consumed resources are the multiset union of the consumed resources of each organism.
* An ecosystem's required resources are the multiset maxunion of the required resources of each organism (i.e. foreach resouce, the environment's requirement is the maximum requirement that any organism has for that resource).
* An ecosystem's available resources are those that are produced but not consumed.
* An ecosystem can support an organism iff all the required and consumed resources of the organism are available in the ecosystem (minus that organism).
* An ecosystem is self-sustaining iff the multiset union of consumed and required resources is a subset of the produced resources.
