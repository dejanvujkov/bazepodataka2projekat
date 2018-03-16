ALTER TABLE popravlja
    ADD CONSTRAINT popravlja_mehanicar_fk FOREIGN KEY ( mehanicar_jmbg )
        REFERENCES mehanicar ( jmbg )