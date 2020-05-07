/*
INSERT INTO tblCameraBrand
VALUES 
	('Canon', 'This is the decription for Canon.'),
	('Nikon', 'This is the description for Nikon.'),
    ('Sony', 'This is the description for Sony.'),
	('Leica', 'This is the description for Leica.')
;
*/

INSERT INTO tblCameraModel
VALUES
	('Canon EOS 700D', 'A good camera for hobby photographers', '2013-03-21', 5, 800.00, 'EF / EF-S', null , '2020-07-05', null, 'DSLR', 'Canon'),
	('Nikon D3100', 'A good camera for hobby photographers and beginners', '2010-08-20', 5, 400.00, 'EF', null , '2020-07-05', null, 'DSLR', 'Nikon'),
	('Sony a7', 'A camera for advanced or profesional photographers', '2013-10-16', 5, 1000.00, 'EF', null , '2020-07-05', null, 'DSLR', 'Sony'),
	('Leica M10', 'A small form camera for profesional photographers', '2017-09-21', 5, 3000.00, 'M Mount' , null , '2020-07-05', null, 'DSLR', 'Leica')
;


INSERT INTO tblOrder
VALUES
	(1, '2020-01-22', 800.00, 1, 'John Doe', 'john-doe@email.com', 'Canon EOS 700D'),
    (2, '2020-02-23', 400.00, 2, 'Jane Doe', 'jane-doe@email.com', 'Nikon D3100'),
	(3, '2020-03-24', 800.00, 1, 'Jane Doe', 'jane-doe@email.com', 'Canon EOS700D')
;
