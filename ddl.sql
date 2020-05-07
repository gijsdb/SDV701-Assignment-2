DROP TABLE IF EXISTS tblCameraModel;
DROP TABLE IF EXISTS tblOrder;
DROP TABLE IF EXISTS tblCameraBrand;


CREATE TABLE tblCameraBrand (
	camera_brand VARCHAR(30) NOT NULL UNIQUE,
    description VARCHAR (255) NOT NULL,
    PRIMARY KEY (camera_brand)
); 

CREATE TABLE tblCameraModel (
	model_name VARCHAR(30) NOT NULL UNIQUE,
    description VARCHAR(255) NOT NULL,
    release_year DATE NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL(8,2) NOT NULL,
    lens_mount VARCHAR(15),
    zoom_range VARCHAR(15),
    last_modified DATE NOT NULL,
    image VARBINARY(max),
    camera_type VARCHAR(15),
    camera_brand VARCHAR(30) NOT NULL,
    PRIMARY KEY (model_name),
    FOREIGN KEY (camera_brand) REFERENCES tblCameraBrand(camera_brand)
);

CREATE TABLE tblOrder (
	order_id INT NOT NULL UNIQUE,
    order_date DATE NOT NULL,
    price DECIMAL(8,2) NOT NULL,
    quantity TINYINT NOT NULL,
    customer_name VARCHAR(100) NOT NULL,
    customer_address VARCHAR(255) NOT NULL,
    model_name VARCHAR(30) NOT NULL,
    PRIMARY KEY (order_id),
    FOREIGN KEY (model_name) REFERENCES tblCameraModel(model_name)
);