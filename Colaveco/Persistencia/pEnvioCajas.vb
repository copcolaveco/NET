Public Class pEnvioCajas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "INSERT INTO enviocajas (id, idpedido, idproductor, idcaja, gradilla1, gradilla2, gradilla3, frascos, idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio) VALUES (" & obj.ID & ", " & obj.IDPEDIDO & "," & obj.IDPRODUCTOR & ",'" & obj.IDCAJA & "', '" & obj.GRADILLA1 & "','" & obj.GRADILLA2 & "','" & obj.GRADILLA3 & "'," & obj.FRASCOS & "," & obj.IDEMPRESA & ",'" & obj.ENVIO & "', '" & obj.FECHAENVIO & "', '" & obj.OBSERVACIONES & "', " & obj.ENVIADO & ", " & obj.IDAGENCIA & ", '" & obj.RECIBO & "', '" & obj.FECHARECIBO & "'," & obj.RECIBIDO & "," & obj.CLIENTE & ", '" & obj.OBSRECIBO & "', " & obj.RESPONSABLE & ", " & obj.CARGADA & ", " & obj.CONVENIO & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "UPDATE enviocajas SET idpedido =" & obj.IDPEDIDO & ", idproductor =" & obj.IDPRODUCTOR & ",idcaja ='" & obj.IDCAJA & "',gradilla1 ='" & obj.GRADILLA1 & "',gradilla2 ='" & obj.GRADILLA2 & "',gradilla3 ='" & obj.GRADILLA3 & "',frascos =" & obj.FRASCOS & ", idempresa =" & obj.IDEMPRESA & ", envio='" & obj.ENVIO & "', fechaenvio='" & obj.FECHAENVIO & "', observaciones='" & obj.OBSERVACIONES & "', enviado=" & obj.ENVIADO & ", idagencia=" & obj.IDAGENCIA & ", recibo='" & obj.RECIBO & "', fecharecibo='" & obj.FECHARECIBO & "', recibido= " & obj.RECIBIDO & ", cliente= " & obj.CLIENTE & ", obsrecibido='" & obj.OBSRECIBO & "', responsable =" & obj.RESPONSABLE & ", cargada =" & obj.CARGADA & ", convenio =" & obj.CONVENIO & "  WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "DELETE FROM enviocajas WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'enviocajas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEnvioCajas
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim e As New dEnvioCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas WHERE idpedido = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.IDPEDIDO = CType(unaFila.Item(1), Long)
                e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                e.IDCAJA = CType(unaFila.Item(3), String)
                e.GRADILLA1 = CType(unaFila.Item(4), String)
                e.GRADILLA2 = CType(unaFila.Item(5), String)
                e.GRADILLA3 = CType(unaFila.Item(6), String)
                e.FRASCOS = CType(unaFila.Item(7), Integer)
                e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                e.ENVIO = CType(unaFila.Item(9), String)
                e.FECHAENVIO = CType(unaFila.Item(10), String)
                e.OBSERVACIONES = CType(unaFila.Item(11), String)
                e.ENVIADO = CType(unaFila.Item(12), Integer)
                e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                e.RECIBO = CType(unaFila.Item(14), String)
                e.FECHARECIBO = CType(unaFila.Item(15), String)
                e.RECIBIDO = CType(unaFila.Item(16), Integer)
                e.CLIENTE = CType(unaFila.Item(17), Long)
                e.OBSRECIBO = CType(unaFila.Item(18), String)
                e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                e.CARGADA = CType(unaFila.Item(20), Integer)
                e.CONVENIO = CType(unaFila.Item(21), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscar2(ByVal o As Object) As dEnvioCajas
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim e As New dEnvioCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.IDPEDIDO = CType(unaFila.Item(1), Long)
                e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                e.IDCAJA = CType(unaFila.Item(3), String)
                e.GRADILLA1 = CType(unaFila.Item(4), String)
                e.GRADILLA2 = CType(unaFila.Item(5), String)
                e.GRADILLA3 = CType(unaFila.Item(6), String)
                e.FRASCOS = CType(unaFila.Item(7), Integer)
                e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                e.ENVIO = CType(unaFila.Item(9), String)
                e.FECHAENVIO = CType(unaFila.Item(10), String)
                e.OBSERVACIONES = CType(unaFila.Item(11), String)
                e.ENVIADO = CType(unaFila.Item(12), Integer)
                e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                e.RECIBO = CType(unaFila.Item(14), String)
                e.FECHARECIBO = CType(unaFila.Item(15), String)
                e.RECIBIDO = CType(unaFila.Item(16), Integer)
                e.CLIENTE = CType(unaFila.Item(17), Long)
                e.OBSRECIBO = CType(unaFila.Item(18), String)
                e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                e.CARGADA = CType(unaFila.Item(20), Integer)
                e.CONVENIO = CType(unaFila.Item(21), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxenvio(ByVal o As Object) As dEnvioCajas
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim e As New dEnvioCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio  FROM enviocajas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.IDPEDIDO = CType(unaFila.Item(1), Long)
                e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                e.IDCAJA = CType(unaFila.Item(3), String)
                e.GRADILLA1 = CType(unaFila.Item(4), String)
                e.GRADILLA2 = CType(unaFila.Item(5), String)
                e.GRADILLA3 = CType(unaFila.Item(6), String)
                e.FRASCOS = CType(unaFila.Item(7), Integer)
                e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                e.ENVIO = CType(unaFila.Item(9), String)
                e.FECHAENVIO = CType(unaFila.Item(10), String)
                e.OBSERVACIONES = CType(unaFila.Item(11), String)
                e.ENVIADO = CType(unaFila.Item(12), Integer)
                e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                e.RECIBO = CType(unaFila.Item(14), String)
                e.FECHARECIBO = CType(unaFila.Item(15), String)
                e.RECIBIDO = CType(unaFila.Item(16), Integer)
                e.CLIENTE = CType(unaFila.Item(17), Long)
                e.OBSRECIBO = CType(unaFila.Item(18), String)
                e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                e.CARGADA = CType(unaFila.Item(20), Integer)
                e.CONVENIO = CType(unaFila.Item(21), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimoenvio(ByVal o As Object) As dEnvioCajas
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim e As New dEnvioCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio  FROM enviocajas WHERE idcaja = '" & obj.IDCAJA & "' and recibido = 0 order by id desc limit 0,1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.IDPEDIDO = CType(unaFila.Item(1), Long)
                e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                e.IDCAJA = CType(unaFila.Item(3), String)
                e.GRADILLA1 = CType(unaFila.Item(4), String)
                e.GRADILLA2 = CType(unaFila.Item(5), String)
                e.GRADILLA3 = CType(unaFila.Item(6), String)
                e.FRASCOS = CType(unaFila.Item(7), Integer)
                e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                e.ENVIO = CType(unaFila.Item(9), String)
                e.FECHAENVIO = CType(unaFila.Item(10), String)
                e.OBSERVACIONES = CType(unaFila.Item(11), String)
                e.ENVIADO = CType(unaFila.Item(12), Integer)
                e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                e.RECIBO = CType(unaFila.Item(14), String)
                e.FECHARECIBO = CType(unaFila.Item(15), String)
                e.RECIBIDO = CType(unaFila.Item(16), Integer)
                e.CLIENTE = CType(unaFila.Item(17), Long)
                e.OBSRECIBO = CType(unaFila.Item(18), String)
                e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                e.CARGADA = CType(unaFila.Item(20), Integer)
                e.CONVENIO = CType(unaFila.Item(21), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimoenvioxcaja(ByVal o As Object) As dEnvioCajas
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim e As New dEnvioCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio  FROM enviocajas WHERE idcaja = '" & obj.IDCAJA & "' order by id desc limit 0,1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.IDPEDIDO = CType(unaFila.Item(1), Long)
                e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                e.IDCAJA = CType(unaFila.Item(3), String)
                e.GRADILLA1 = CType(unaFila.Item(4), String)
                e.GRADILLA2 = CType(unaFila.Item(5), String)
                e.GRADILLA3 = CType(unaFila.Item(6), String)
                e.FRASCOS = CType(unaFila.Item(7), Integer)
                e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                e.ENVIO = CType(unaFila.Item(9), String)
                e.FECHAENVIO = CType(unaFila.Item(10), String)
                e.OBSERVACIONES = CType(unaFila.Item(11), String)
                e.ENVIADO = CType(unaFila.Item(12), Integer)
                e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                e.RECIBO = CType(unaFila.Item(14), String)
                e.FECHARECIBO = CType(unaFila.Item(15), String)
                e.RECIBIDO = CType(unaFila.Item(16), Integer)
                e.CLIENTE = CType(unaFila.Item(17), Long)
                e.OBSRECIBO = CType(unaFila.Item(18), String)
                e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                e.CARGADA = CType(unaFila.Item(20), Integer)
                e.CONVENIO = CType(unaFila.Item(21), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio  FROM enviocajas order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincargar() As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas WHERE idempresa = 7 and cargada = 0 or idempresa = 13  and cargada = 0 or idempresa = 15  and cargada = 0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincargar2() As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas WHERE idempresa <> 7 and idempresa <> 13 and cargada = 0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcargadas() As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas Where cargada = 1 order by fechaenvio desc LIMIT 100"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinenvio() As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos, idempresa, envio, fechaenvio, observaciones, enviado, idagencia, ifnull(recibo,''), fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas WHERE idempresa <> 7 and idempresa <> 13 and envio='' order by id desc LIMIT 100"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsindevolver(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas where recibido = 0 AND  idcaja <> '' AND fechaenvio >= '" & desde & "' AND fechaenvio <= '" & hasta & "' order by fechaenvio asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarverdessindevolver() As ArrayList
        'Dim sql As String = "SELECT id, idpedido,idproductor, idcaja, gradilla1, gradilla2, gradilla3,frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, obsrecibo, responsable FROM enviocajas where (recibido = 0 AND  idcaja >= 1 AND idcaja <= 199) OR (recibido = 0 AND idcaja >=300 AND idcaja <=399) order by fechaenvio asc"
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas where recibido = 0  order by fechaenvio asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsindevolver2(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, obsrecibo, responsable, cargada, convenio FROM enviocajas where recibido = 0 AND idcaja <> '' AND fechaenvio >= '" & desde & "' AND fechaenvio <= '" & hasta & "' order by idcaja asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idpedido = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxcaja(ByVal caja As String) As ArrayList
        'Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable FROM enviocajas where idcaja = '" & caja & "' AND recibido =0 ORDER BY fechaenvio desc ")
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idcaja = '" & caja & "' ORDER BY fechaenvio desc ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxcaja_asc(ByVal caja As String) As ArrayList
        'Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable FROM enviocajas where idcaja = '" & caja & "' AND recibido =0 ORDER BY fechaenvio desc ")
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idcaja = '" & caja & "' ORDER BY fechaenvio asc ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimoenvio(ByVal caja As String) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idcaja = '" & caja & "' ORDER BY fechaenvio desc LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxcajatodos(ByVal caja As String) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idcaja = '" & caja & "' ORDER BY fechaenvio desc ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxcajasindevolver(ByVal caja As String) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idcaja = '" & caja & "' AND recibido =0 ORDER BY fechaenvio desc ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        'Dim sql As String = ("SELECT id, idpedido, idproductor, idcaja, gradilla1, gradilla2, gradilla3, frascos, idempresa, envio, fechaenvio, observaciones, enviado, idagencia, ifnull(recibo,''), fecharecibo, recibido, ifnull(obsrecibo,'') FROM enviocajas where fecha between ('" & desde & "','" & hasta & "')")
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where fechaenvio >='" & desde & "' and fechaenvio <='" & hasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfechaxcliente(ByVal desde As String, ByVal hasta As String, ByVal cliente As Long) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idproductor =" & cliente & " and fechaenvio >='" & desde & "' and fechaenvio <='" & hasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporcliente(ByVal cliente As Long) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idproductor = " & cliente & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxcliente(ByVal cliente As Long) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idproductor = " & cliente & " AND recibido =0 AND idcaja <>'Cons-Devolución'  AND idcaja <>'Cons-Devolu'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarEnvio(ByVal id As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE enviocajas SET enviado = 1 WHERE idpedido = " & id & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'enviocajas', 'marcar envio', " & id & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function marcarrecibido(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "UPDATE enviocajas SET idagencia=" & obj.IDAGENCIA & ", recibo='" & obj.RECIBO & "', fecharecibo='" & obj.FECHARECIBO & "', recibido= " & obj.RECIBIDO & ", cliente= " & obj.CLIENTE & ",obsrecibo='" & obj.OBSRECIBO & "'  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'marcar recibido', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
  
    Public Function desmarcarrecibido(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "UPDATE enviocajas SET idagencia=" & obj.IDAGENCIA & ", recibo='" & obj.RECIBO & "', fecharecibo='" & obj.FECHARECIBO & "', recibido= " & obj.RECIBIDO & ", obsrecibo='" & obj.OBSRECIBO & "'  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'desmarcar recibido', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcargada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "UPDATE enviocajas SET cargada = 1  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'marcar recibido', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function desmarcarcargada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "UPDATE enviocajas SET cargada = 0  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'desmarcar recibido', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function listarporpedido(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idpedido, idproductor,idcaja, ifnull(gradilla1,''), ifnull(gradilla2,''), ifnull(gradilla3,''), frascos,idempresa, envio, fechaenvio, observaciones, enviado, idagencia, recibo, fecharecibo, recibido, cliente, ifnull(obsrecibo,''), responsable, cargada, convenio FROM enviocajas where idpedido = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dEnvioCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.IDPEDIDO = CType(unaFila.Item(1), Long)
                    e.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), String)
                    e.GRADILLA2 = CType(unaFila.Item(5), String)
                    e.GRADILLA3 = CType(unaFila.Item(6), String)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.IDEMPRESA = CType(unaFila.Item(8), Integer)
                    e.ENVIO = CType(unaFila.Item(9), String)
                    e.FECHAENVIO = CType(unaFila.Item(10), String)
                    e.OBSERVACIONES = CType(unaFila.Item(11), String)
                    e.ENVIADO = CType(unaFila.Item(12), Integer)
                    e.IDAGENCIA = CType(unaFila.Item(13), Integer)
                    e.RECIBO = CType(unaFila.Item(14), String)
                    e.FECHARECIBO = CType(unaFila.Item(15), String)
                    e.RECIBIDO = CType(unaFila.Item(16), Integer)
                    e.CLIENTE = CType(unaFila.Item(17), Long)
                    e.OBSRECIBO = CType(unaFila.Item(18), String)
                    e.RESPONSABLE = CType(unaFila.Item(19), Integer)
                    e.CARGADA = CType(unaFila.Item(20), Integer)
                    e.CONVENIO = CType(unaFila.Item(21), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function completarenvio(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEnvioCajas = CType(o, dEnvioCajas)
        Dim sql As String = "UPDATE enviocajas SET envio='" & obj.ENVIO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_cajas', 'completar envio', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
End Class
