CREATE PROCEDURE orderCamera(@prModelName varchar(255))
AS
	DECLARE @isCameraAvailable INT;
	SELECT @isCameraAvailable = (
		SELECT 1 FROM tblCameraModel WHERE model_name = @prModelName AND quantity >= 1
	);

	IF @isCameraAvailable >= 1 
	BEGIN 
		PRINT 'The camera is available'
	END
	ELSE 
	BEGIN
		PRINT 'The camera is not available'
	END