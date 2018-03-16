ALTER TABLE koji
    ADD CONSTRAINT koji_poseduje_fk FOREIGN KEY ( poseduje_idstanice,
    poseduje_brtablica )
        REFERENCES poseduje ( autobuska_stanica_idstanice,
        autobus_brtablica )