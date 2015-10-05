## What database models do you know? ##
*	Hierarchical (tree)
*	Graph
*	Relational
*	Object-oriented


## Which are the main functions performed by a Relational Database Management System (RDBMS)? ##
A Relational DBMS is used for managing the organization, storage, access, security, and integrity of data. It provides functionalities for adding, modifying, deleting, and displaying data.

## Define what is "table" in database terms. ##
A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows. A table has a specified number of columns, but can have any number of rows. Each row is identified by one or more values appearing in a particular column subset. The columns subset which uniquely identifies a row is called the primary key. Table is another term for relation; although there is the difference in that a table is usually a multiset (bag) of rows where a relation is a set and does not allow duplicates. Besides the actual data rows, tables generally have associated with them some metadata, such as constraints on the table or on the values within particular columns.

## Explain the difference between a primary and a foreign key. ##

  * Primary key of a table uniquely identifies its row. In order to achieve data integrity, in other words to avoid repeating data, each row in the table must be assigned unique primary key.

  * Foreign key is used to make the relationship between two tables. The foreign key of the child table points to the primary key of the parent table. The primary key of the parent table corresponds to the foreign key of the child table. Data are retrieved from the parent table and filled as information part of the child table when query statements are executed. Foreign key constraint ensures data integrity of the database. Duplication and incorrectness of data are avoided.

## Explain the different kinds of relationships between tables in relational databases. ##
One-to-one:
Both tables can have only one record on either side of the relationship.
Each primary key value relates to only one (or no) record in the related table.
They're like spouses—you may or may not be married, but if you are,
both you and your spouse have only one spouse.
Most one-to-one relationships are forced by business rules and don't flow naturally from the data. In the absence of such a rule, you can usually combine both tables
into one table without breaking any normalization rules.

One-to-many:
The primary key table contains only one record that relates to none, one,
or many records in the related table.
This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.

Many-to-many:
Each record in both tables can relate to any number of records (or no records) in the other table.
For instance, if you have several siblings, so do your siblings (have many siblings).
Many-to-many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship.

## When is a certain database schema normalized? What are the advantages of normalized databases? ##
Database normalization is the process of organizing the attributes and tables of a relational database to minimize data redundancy.
Normalization involves decomposing a table into less redundant (and smaller) tables but without losing information;
defining foreign keys in the old table referencing the primary keys of the new ones. The objective is to isolate data so that additions,
deletions, and modifications of an attribute can be made in just one table and then propagated through the rest of the database using the defined foreign keys.

The aforementioned leads to smaller databases, better performance and less columns per table, allowing for more records

## What are database integrity constraints and when are they used? ##
Integrity constraints are used to ensure accuracy and consistency of data in a relational database.
Data integrity is handled in a relational database through the concept of referential integrity.
Many types of integrity constraints play a role in referential integrity (RI).
  * Primary Key Constraints
  * Unique Constraints
  * Foreign Key Constraints
  * NOT NULL Constraints
  * Check Constraints
  * Dropping Constraints

## Point out the pros and cons of using indexes in a DB ##
* Advantages:
Faster lookup for results. This is all about reducing the # of Disk IO's. Instead of scanning the entire table for the results, you can reduce the number of disk IO's(page fetches) by using index structures such as B-Trees or Hash Indexes to get to your data faster.

* Disadvantages: Slower writing of data. Besides saving entries, you also write in a structure (most commonly B-tree) which can often be an expensive operation. Stores even more data on the disk.

## What's the main purpose of the SQL language? ##
The SQL Language is one of many tools for communication with the database

## What are transactions used for? Provide Examples. ##
A transaction is a set of changes that must all be made together.  Transaction is executed as a single unit. If the database was in consistent state before a transaction, then after execution of the transaction also, the database must be in a consistent state.

Example: a transfer of money from one bank account to another requires two changes to the database both must succeed or fail together.
If you send 100$ from your bank account (A) to another account (B) there will be two operations.

* Withdraw the money from the account A
* Add the money to account B

If either of the two operations fails, both of them should fail.

## Explain the classical non-relational data models. ##
NoSQL are non-relational database. There are no relationships between the elements of the database. There is no data consistency. No columns and their corresponding types and rules exist.

## Give few examples of NoSQL DBs and their pros and cons. ##
* MongoDB. Open-source document database.
* CouchDB. Database that uses JSON for documents, JavaScript for MapReduce queries, and regular HTTP for an API.
* GemFire. Distributed data management platform providing dynamic scalability, high performance, and database-like persistence.
* Redis. Data structure server wherein keys can contain strings, hashes, lists, sets, and sorted sets.
* Cassandra. Database that provides scalability and high availability without compromising performance.
memcached. Open source high-performance, distributed-memory, and object-caching system.
* Hazelcast. Open source highly scalable data distribution platform.
* HBase. Hadoop database, a distributed and scalable big data store.
* Mnesia. Distributed database management system that exhibits soft real-time properties.
* Neo4j. Open source high-performance, enterprise-grade graph database.
