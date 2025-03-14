ALTER TABLE collections
    ADD COLUMN slug TEXT GENERATED ALWAYS AS (lower(replace(name, ' ', '-'))) STORED;

ALTER TABLE collections
    ADD COLUMN release_date DATE;

ALTER TABLE categories
    ADD COLUMN slug TEXT GENERATED ALWAYS AS (lower(replace(name, ' ', '-'))) STORED;
    
ALTER TABLE articles
    ADD COLUMN slug TEXT GENERATED ALWAYS AS (lower(replace(name, ' ', '-'))) STORED;
