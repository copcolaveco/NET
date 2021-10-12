Public Class pNuevoCliente
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim sql As String = "INSERT INTO nuevo_cliente (id, pedido, envio, tipousuario, nombre, rsocial, rut, direccion, localidad, departamento, dicose, telefono, celular, email, tecnico, direccionenvio, agencia, cnombre, ccelular, ctelefono, cemail, enviado) VALUES (" & obj.ID & ", " & obj.PEDIDO & ", " & obj.ENVIO & "," & obj.TIPOUSUARIO & ",'" & obj.NOMBRE & "', '" & obj.RAZON_SOCIAL & "','" & obj.RUT & "', '" & obj.DIRECCION & "', " & obj.IDLOCALIDAD & ", " & obj.IDDEPARTAMENTO & ", '" & obj.DICOSE & "', '" & obj.TELEFONO & "', '" & obj.CELULAR & "', '" & obj.EMAIL & "', " & obj.TECNICO & ", '" & obj.DIRECCIONENVIO & "', " & obj.IDAGENCIA & ", '" & obj.CNOMBRE & "', '" & obj.CCELULAR & "', '" & obj.CTELEFONO & "', '" & obj.CEMAIL & "', " & obj.ENVIADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevo_cliente', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim sql As String = "UPDATE nuevo_cliente SET  pedido = " & obj.PEDIDO & ", envio = " & obj.ENVIO & ", tipousuario= " & obj.TIPOUSUARIO & ", nombre = '" & obj.NOMBRE & "', rsocial = '" & obj.RAZON_SOCIAL & "', rut = '" & obj.RUT & "', direccion = '" & obj.DIRECCION & "', localidad =  " & obj.IDLOCALIDAD & ", departamento = " & obj.IDDEPARTAMENTO & ", dicose = '" & obj.DICOSE & "', telefono = '" & obj.TELEFONO & "', celular = '" & obj.CELULAR & "', email = '" & obj.EMAIL & "', tecnico = " & obj.TECNICO & ", direccionenvio = '" & obj.DIRECCIONENVIO & "', agencia = " & obj.IDAGENCIA & ", cnombre = '" & obj.CNOMBRE & "', ccelular = '" & obj.CCELULAR & "', ctelefono = '" & obj.CTELEFONO & "', cemail = '" & obj.CEMAIL & "', enviado = " & obj.ENVIADO & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevo_cliente', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarenviado(ByVal o As Object) As Boolean
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim sql As String = "UPDATE nuevo_cliente SET enviado = 1 WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim sql As String = "DELETE FROM nuevo_cliente WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevo_cliente', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNuevoCliente
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim c As New dNuevoCliente
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, pedido, envio, tipousuario, ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), localidad, departamento, ifnull(dicose,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), tecnico, ifnull(direccionenvio,''), agencia, ifnull(cnombre,''), ifnull(ccelular,''), ifnull(ctelefono,''), ifnull(cemail,''), enviado FROM nuevo_cliente WHERE ID = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.PEDIDO = CType(unaFila.Item(1), Long)
                c.ENVIO = CType(unaFila.Item(2), Long)
                c.TIPOUSUARIO = CType(unaFila.Item(3), Integer)
                c.NOMBRE = CType(unaFila.Item(4), String)
                c.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                c.RUT = CType(unaFila.Item(6), String)
                c.DIRECCION = CType(unaFila.Item(7), String)
                c.IDLOCALIDAD = CType(unaFila.Item(8), Integer)
                c.IDDEPARTAMENTO = CType(unaFila.Item(9), Integer)
                c.DICOSE = CType(unaFila.Item(10), String)
                c.TELEFONO = CType(unaFila.Item(11), String)
                c.CELULAR = CType(unaFila.Item(12), String)
                c.EMAIL = CType(unaFila.Item(13), String)
                c.TECNICO = CType(unaFila.Item(14), Long)
                c.DIRECCIONENVIO = CType(unaFila.Item(15), String)
                c.IDAGENCIA = CType(unaFila.Item(16), Integer)
                c.CNOMBRE = CType(unaFila.Item(17), String)
                c.CCELULAR = CType(unaFila.Item(18), String)
                c.CTELEFONO = CType(unaFila.Item(19), String)
                c.CEMAIL = CType(unaFila.Item(20), String)
                c.ENVIADO = CType(unaFila.Item(21), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dNuevoCliente
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim c As New dNuevoCliente
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, pedido, envio, tipousuario, ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), localidad, departamento, ifnull(dicose,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), tecnico, ifnull(direccionenvio,''), agencia, ifnull(cnombre,''), ifnull(ccelular,''), ifnull(ctelefono,''), ifnull(cemail,''), enviado FROM nuevo_cliente ORDER By id DESC LIMIT 1 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.PEDIDO = CType(unaFila.Item(1), Long)
                c.ENVIO = CType(unaFila.Item(2), Long)
                c.TIPOUSUARIO = CType(unaFila.Item(3), Integer)
                c.NOMBRE = CType(unaFila.Item(4), String)
                c.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                c.RUT = CType(unaFila.Item(6), String)
                c.DIRECCION = CType(unaFila.Item(7), String)
                c.IDLOCALIDAD = CType(unaFila.Item(8), Integer)
                c.IDDEPARTAMENTO = CType(unaFila.Item(9), Integer)
                c.DICOSE = CType(unaFila.Item(10), String)
                c.TELEFONO = CType(unaFila.Item(11), String)
                c.CELULAR = CType(unaFila.Item(12), String)
                c.EMAIL = CType(unaFila.Item(13), String)
                c.TECNICO = CType(unaFila.Item(14), Long)
                c.DIRECCIONENVIO = CType(unaFila.Item(15), String)
                c.IDAGENCIA = CType(unaFila.Item(16), Integer)
                c.CNOMBRE = CType(unaFila.Item(17), String)
                c.CCELULAR = CType(unaFila.Item(18), String)
                c.CTELEFONO = CType(unaFila.Item(19), String)
                c.CEMAIL = CType(unaFila.Item(20), String)
                c.ENVIADO = CType(unaFila.Item(21), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcar(ByVal o As Object) As Boolean
        Dim obj As dNuevoCliente = CType(o, dNuevoCliente)
        Dim sql As String = "UPDATE nuevo_cliente SET enviado = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, pedido, envio, tipousuario, ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), localidad, departamento, ifnull(dicose,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), tecnico, ifnull(direccionenvio,''), agencia, ifnull(cnombre,''), ifnull(ccelular,''), ifnull(ctelefono,''), ifnull(cemail,''), enviado FROM nuevo_cliente ORDER by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dNuevoCliente
                    c.ID = CType(unaFila.Item(0), Long)
                    c.PEDIDO = CType(unaFila.Item(1), Long)
                    c.ENVIO = CType(unaFila.Item(2), Long)
                    c.TIPOUSUARIO = CType(unaFila.Item(3), Integer)
                    c.NOMBRE = CType(unaFila.Item(4), String)
                    c.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    c.RUT = CType(unaFila.Item(6), String)
                    c.DIRECCION = CType(unaFila.Item(7), String)
                    c.IDLOCALIDAD = CType(unaFila.Item(8), Integer)
                    c.IDDEPARTAMENTO = CType(unaFila.Item(9), Integer)
                    c.DICOSE = CType(unaFila.Item(10), String)
                    c.TELEFONO = CType(unaFila.Item(11), String)
                    c.CELULAR = CType(unaFila.Item(12), String)
                    c.EMAIL = CType(unaFila.Item(13), String)
                    c.TECNICO = CType(unaFila.Item(14), Long)
                    c.DIRECCIONENVIO = CType(unaFila.Item(15), String)
                    c.IDAGENCIA = CType(unaFila.Item(16), Integer)
                    c.CNOMBRE = CType(unaFila.Item(17), String)
                    c.CCELULAR = CType(unaFila.Item(18), String)
                    c.CTELEFONO = CType(unaFila.Item(19), String)
                    c.CEMAIL = CType(unaFila.Item(20), String)
                    c.ENVIADO = CType(unaFila.Item(21), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim sql As String = "SELECT id, pedido, envio, tipousuario, ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), localidad, departamento, ifnull(dicose,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), tecnico, ifnull(direccionenvio,''), agencia, ifnull(cnombre,''), ifnull(ccelular,''), ifnull(ctelefono,''), ifnull(cemail,''), enviado FROM nuevo_cliente WHERE enviado = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dNuevoCliente
                    c.ID = CType(unaFila.Item(0), Long)
                    c.PEDIDO = CType(unaFila.Item(1), Long)
                    c.ENVIO = CType(unaFila.Item(2), Long)
                    c.TIPOUSUARIO = CType(unaFila.Item(3), Integer)
                    c.NOMBRE = CType(unaFila.Item(4), String)
                    c.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    c.RUT = CType(unaFila.Item(6), String)
                    c.DIRECCION = CType(unaFila.Item(7), String)
                    c.IDLOCALIDAD = CType(unaFila.Item(8), Integer)
                    c.IDDEPARTAMENTO = CType(unaFila.Item(9), Integer)
                    c.DICOSE = CType(unaFila.Item(10), String)
                    c.TELEFONO = CType(unaFila.Item(11), String)
                    c.CELULAR = CType(unaFila.Item(12), String)
                    c.EMAIL = CType(unaFila.Item(13), String)
                    c.TECNICO = CType(unaFila.Item(14), Long)
                    c.DIRECCIONENVIO = CType(unaFila.Item(15), String)
                    c.IDAGENCIA = CType(unaFila.Item(16), Integer)
                    c.CNOMBRE = CType(unaFila.Item(17), String)
                    c.CCELULAR = CType(unaFila.Item(18), String)
                    c.CTELEFONO = CType(unaFila.Item(19), String)
                    c.CEMAIL = CType(unaFila.Item(20), String)
                    c.ENVIADO = CType(unaFila.Item(21), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function buscarPorNombreTodos(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, pedido, envio, tipousuario, ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), localidad, departamento, ifnull(dicose,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), tecnico, ifnull(direccionenvio,''), agencia, ifnull(cnombre,''), ifnull(ccelular,''), ifnull(ctelefono,''), ifnull(cemail,''), enviado FROM nuevo_cliente WHERE Nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim c As New dNuevoCliente()
                    c.ID = CType(unaFila.Item(0), Long)
                    c.PEDIDO = CType(unaFila.Item(1), Long)
                    c.ENVIO = CType(unaFila.Item(2), Long)
                    c.TIPOUSUARIO = CType(unaFila.Item(3), Integer)
                    c.NOMBRE = CType(unaFila.Item(4), String)
                    c.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    c.RUT = CType(unaFila.Item(6), String)
                    c.DIRECCION = CType(unaFila.Item(7), String)
                    c.IDLOCALIDAD = CType(unaFila.Item(8), Integer)
                    c.IDDEPARTAMENTO = CType(unaFila.Item(9), Integer)
                    c.DICOSE = CType(unaFila.Item(10), String)
                    c.TELEFONO = CType(unaFila.Item(11), String)
                    c.CELULAR = CType(unaFila.Item(12), String)
                    c.EMAIL = CType(unaFila.Item(13), String)
                    c.TECNICO = CType(unaFila.Item(14), Long)
                    c.DIRECCIONENVIO = CType(unaFila.Item(15), String)
                    c.IDAGENCIA = CType(unaFila.Item(16), Integer)
                    c.CNOMBRE = CType(unaFila.Item(17), String)
                    c.CCELULAR = CType(unaFila.Item(18), String)
                    c.CTELEFONO = CType(unaFila.Item(19), String)
                    c.CEMAIL = CType(unaFila.Item(20), String)
                    c.ENVIADO = CType(unaFila.Item(21), Integer)
                    listaResultado.Add(c)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, pedido, envio, tipousuario, ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), localidad, departamento, ifnull(dicose,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), tecnico, ifnull(direccionenvio,''), agencia, ifnull(cnombre,''), ifnull(ccelular,''), ifnull(ctelefono,''), ifnull(cemail,''), enviado FROM nuevo_cliente WHERE Nombre LIKE '%" & pNombre & "%' AND nousar =0"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim c As New dNuevoCliente()
                    c.ID = CType(unaFila.Item(0), Long)
                    c.PEDIDO = CType(unaFila.Item(1), Long)
                    c.ENVIO = CType(unaFila.Item(2), Long)
                    c.TIPOUSUARIO = CType(unaFila.Item(3), Integer)
                    c.NOMBRE = CType(unaFila.Item(4), String)
                    c.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    c.RUT = CType(unaFila.Item(6), String)
                    c.DIRECCION = CType(unaFila.Item(7), String)
                    c.IDLOCALIDAD = CType(unaFila.Item(8), Integer)
                    c.IDDEPARTAMENTO = CType(unaFila.Item(9), Integer)
                    c.DICOSE = CType(unaFila.Item(10), String)
                    c.TELEFONO = CType(unaFila.Item(11), String)
                    c.CELULAR = CType(unaFila.Item(12), String)
                    c.EMAIL = CType(unaFila.Item(13), String)
                    c.TECNICO = CType(unaFila.Item(14), Long)
                    c.DIRECCIONENVIO = CType(unaFila.Item(15), String)
                    c.IDAGENCIA = CType(unaFila.Item(16), Integer)
                    c.CNOMBRE = CType(unaFila.Item(17), String)
                    c.CCELULAR = CType(unaFila.Item(18), String)
                    c.CTELEFONO = CType(unaFila.Item(19), String)
                    c.CEMAIL = CType(unaFila.Item(20), String)
                    c.ENVIADO = CType(unaFila.Item(21), Integer)
                    listaResultado.Add(c)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
End Class
