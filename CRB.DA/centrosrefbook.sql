CREATE DATABASE centros_ref_book;

CREATE SCHEMA crb;

CREATE TABLE crb.currency(
  "Id" serial primary key,
  "Name" varchar(200),
  "NumericCode" varchar(10),
  "AlphaCode" varchar(10) not null,
  "Price" decimal not null,
  "Scale" integer,
  "Date" date not null,
  "RecordDate" timestamp
  );

CREATE TABLE crb.metall(
  "Id" serial primary key,
  "Name" varchar(200),
  "AlphaCode" varchar(10) not null,
  "Price" decimal not null,
  "Date" date not null,
  "RecordDate" timestamp
  );
