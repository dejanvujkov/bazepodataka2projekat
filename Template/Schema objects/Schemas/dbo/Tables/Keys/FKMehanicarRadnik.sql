ALTER TABLE Mehanicar
    ADD CONSTRAINT mehanicar_radnik_fk FOREIGN KEY ( jmbg )
        REFERENCES radnik ( jmbg )