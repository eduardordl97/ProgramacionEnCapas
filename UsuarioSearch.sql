ALTER PROCEDURE [dbo].[UsuarioGetAll]
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
	IF(@Nombre = '' AND @ApellidoPaterno = '' AND @ApellidoMaterno = '')
		BEGIN
			SELECT U.Username
		  ,U.Nombre
		  ,U.ApellidoPaterno
		  ,U.ApellidoMaterno
		  ,U.Email
		  ,U.Password
		  ,U.FechaNacimiento
		  ,U.Telefono
		  ,U.Sexo
		  ,U.Status
		  ,U.IdRol
		  ,R.Nombre as NombreRol
      

		FROM Usuario U
		INNER JOIN Rol R
		ON U.IdRol = R.IdRol
		END
	ELSE IF(@Nombre != '' OR @ApellidoPaterno != '' OR @ApellidoMaterno != '')
		BEGIN
			SELECT U.Username
		  ,U.Nombre
		  ,U.ApellidoPaterno
		  ,U.ApellidoMaterno
		  ,U.Email
		  ,U.Password
		  ,U.FechaNacimiento
		  ,U.Telefono
		  ,U.Sexo
		  ,U.Status
		  ,U.IdRol
		  ,R.Nombre as NombreRol
      

		FROM Usuario U
		INNER JOIN Rol R
		ON U.IdRol = R.IdRol
		WHERE U.Nombre LIKE '%'+@Nombre+'%' AND U.ApellidoPaterno LIKE '%'+@ApellidoPaterno+'%' AND U.ApellidoMaterno LIKE '%'+@ApellidoMaterno+'%'
		END
	