CREATE TABLE collections
(
    collection_id UUID PRIMARY KEY,
    name          TEXT NOT NULL
);

CREATE TABLE categories
(
    category_id        UUID PRIMARY KEY,
    name               TEXT NOT NULL,
    parent_category_id UUID REFERENCES categories (category_id)
        CONSTRAINT parent_not_self CHECK (parent_category_id <> category_id)
);

CREATE TABLE articles
(
    article_id  UUID PRIMARY KEY,
    name        TEXT          NOT NULL,
    price       NUMERIC(8, 2) NOT NULL CHECK (price > 0),
    category_id UUID          NOT NULL REFERENCES categories (category_id) ON DELETE RESTRICT
);

CREATE TABLE article_collection
(
    article_id    UUID REFERENCES articles (article_id) ON DELETE CASCADE,
    collection_id UUID REFERENCES collections (collection_id) ON DELETE CASCADE,
    PRIMARY KEY (article_id, collection_id)
);

CREATE INDEX idx_articles_category_id ON articles (category_id);
