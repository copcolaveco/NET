Public Class pSolicitudAnalisis
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "INSERT INTO solicitudanalisis (id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha, observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, obsinternas, codigo, fechaproceso, muestreo, logo, interpretacion, fechamuestreo, solicitudestadoid) VALUES (" & obj.ID & ", '" & obj.FECHAINGRESO & "'," & obj.IDPRODUCTOR & ", " & obj.IDTIPOINFORME & "," & obj.IDSUBINFORME & "," & obj.IDTIPOFICHA & ",'" & obj.OBSERVACIONES & "'," & obj.NMUESTRAS & ", " & obj.IDMUESTRA & ", " & obj.IDTECNICO & ", " & obj.SINCOLICITUD & ", " & obj.SINCONSERVANTE & "," & obj.TEMPERATURA & ", " & obj.DERRAMADAS & ", " & obj.DESVIOAUTORIZADO & ", " & obj.IDFACTURA & ", " & obj.WEB & ", " & obj.PERSONAL & ", " & obj.EMAIL & ", '" & obj.FECHAENVIO & "', " & obj.MARCA & ", " & obj.ELIMINADO & ", " & obj.TAMBO & ", " & obj.PAGO & ", " & obj.IMPORTE & ", " & obj.KMTS & ", '" & obj.OBSINTERNAS & "', '" & obj.CODIGO & "', '" & obj.FECHAPROCESO & "', " & obj.MUESTREO & ", " & obj.LOGO & ", '" & obj.INTERPRETACION & "', '" & obj.FECHAMUESTREO & "', '" & obj.SOLICITUDESTADOID & "')"
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET fechaingreso ='" & obj.FECHAINGRESO & "', idproductor =" & obj.IDPRODUCTOR & ",idtipoinforme =" & obj.IDTIPOINFORME & ",idsubinforme =" & obj.IDSUBINFORME & ",idtipoficha =" & obj.IDTIPOFICHA & ", observaciones ='" & obj.OBSERVACIONES & "', nmuestras=" & obj.NMUESTRAS & ", idmuestra=" & obj.IDMUESTRA & ", idtecnico=" & obj.IDTECNICO & ", sinsolicitud=" & obj.SINCOLICITUD & ", sinconservante=" & obj.SINCONSERVANTE & ", temperatura=" & obj.TEMPERATURA & ", derramadas=" & obj.DERRAMADAS & ", desvio=" & obj.DESVIOAUTORIZADO & ", idfactura=" & obj.IDFACTURA & ", web=" & obj.WEB & ", personal=" & obj.PERSONAL & ", email=" & obj.EMAIL & ", fechaenvio='" & obj.FECHAENVIO & "',marca=" & obj.MARCA & ",eliminado=" & obj.ELIMINADO & ",pago=" & obj.PAGO & ",importe=" & obj.IMPORTE & ",kmts=" & obj.KMTS & ",obsinternas='" & obj.OBSINTERNAS & "',codigo='" & obj.CODIGO & "',fechaproceso='" & obj.FECHAPROCESO & "', muestreo=" & obj.MUESTREO & ", logo=" & obj.LOGO & ", interpretacion='" & obj.INTERPRETACION & "', fechamuestreo='" & obj.FECHAMUESTREO & "', solicitudestadoid='" & obj.SOLICITUDESTADOID & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificartambo(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET tambo=" & obj.TAMBO & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'modifica_tambo', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarobservaciones(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET observaciones='" & obj.OBSERVACIONES & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'modifica_obs', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarinterpretacion(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET interpretacion='" & obj.INTERPRETACION & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'interpretacion', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "DELETE FROM solicitudanalisis WHERE ID = " & obj.ID & ""
        'Dim sql As String = "UPDATE solicitudanalisis SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        'Dim sql As String = "DELETE FROM solicitudanalisis WHERE ID = " & obj.ID & ""
        Dim sql As String = "UPDATE solicitudanalisis SET eliminado =1 WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSolicitudAnalisis
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim s As New dSolicitudAnalisis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo, solicitudestadoid FROM solicitudanalisis WHERE id = " & obj.ID & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHAINGRESO = CType(unaFila.Item(1), String)
                s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                s.OBSERVACIONES = CType(unaFila.Item(6), String)
                s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                s.IDTECNICO = CType(unaFila.Item(9), Long)
                s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                s.TEMPERATURA = CType(unaFila.Item(12), Double)
                s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                s.IDFACTURA = CType(unaFila.Item(15), Long)
                s.WEB = CType(unaFila.Item(16), Integer)
                s.PERSONAL = CType(unaFila.Item(17), Integer)
                s.EMAIL = CType(unaFila.Item(18), Integer)
                s.FECHAENVIO = CType(unaFila.Item(19), String)
                s.MARCA = CType(unaFila.Item(20), Integer)
                s.ELIMINADO = CType(unaFila.Item(21), Integer)
                s.TAMBO = CType(unaFila.Item(22), Integer)
                s.PAGO = CType(unaFila.Item(23), Integer)
                s.IMPORTE = CType(unaFila.Item(24), Double)
                s.KMTS = CType(unaFila.Item(25), Integer)
                s.OBSINTERNAS = CType(unaFila.Item(26), String)
                s.CODIGO = CType(unaFila.Item(27), String)
                s.FECHAPROCESO = CType(unaFila.Item(28), String)
                s.MUESTREO = CType(unaFila.Item(29), Integer)
                s.LOGO = CType(unaFila.Item(30), Integer)
                s.INTERPRETACION = CType(unaFila.Item(31), String)
                s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                s.SOLICITUDESTADOID = CType(unaFila.Item(33), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function existeSolicitudAnalisis(ByVal id As Long) As Boolean
        Try
            ' Ejecutar la consulta SQL para verificar si el ID existe
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT COUNT(*) FROM solicitudanalisis WHERE id = " & id)

            ' Verificar si se obtuvo un resultado y si hay alguna fila
            If Ds.Tables(0).Rows.Count > 0 AndAlso CType(Ds.Tables(0).Rows(0).Item(0), Integer) > 0 Then
                ' Si el conteo es mayor que cero, significa que el ID existe
                Return True
            Else
                ' Si no se encontró ningún resultado, el ID no existe
                Return False
            End If
        Catch ex As Exception
            ' Si ocurre un error en la ejecución, retornar False
            Return False
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where eliminado=0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimos6meses(ByVal f As Long) As ArrayList
        Dim sql As String = "SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where id > " & f & " and eliminado=0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpendientes() As ArrayList
        Dim sql As String = "SELECT s.id, s.fechaingreso, s.idproductor, s.idtipoinforme, s.idsubinforme, s.idtipoficha,observaciones, s.nmuestras, s.idmuestra, s.idtecnico, s.sinsolicitud, s.sinconservante, s.temperatura, s.derramadas, s.desvio, s.idfactura, s.web, s.personal, s.email, s.fechaenvio, s.marca, s.eliminado, s.tambo, s.pago, s.importe, s.kmts, ifnull(s.obsinternas,''), ifnull(s.codigo,''), s.fechaproceso, s.muestreo, s.logo, ifnull(s.interpretacion,''), s.fechamuestreo, count(n.muestra), n.operador FROM solicitudanalisis s join nuevoanalisis n on n.ficha = s.id WHERE marca=0 and eliminado=0 group by s.id order by fechaingreso asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    s.OPERADOR = CType(unaFila.Item(33), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where eliminado = 0 and id = " & texto & " order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxtipo(ByVal texto As Integer) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 and eliminado = 0 and idtipoinforme = " & texto & " order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxtipoxclientexfecha(ByVal tipo As Integer, ByVal cli As Long, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where eliminado = 0 and idtipoinforme = " & tipo & " AND idproductor = " & cli & " AND fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimoid(ByVal o As Object) As dSolicitudAnalisis
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim s As New dSolicitudAnalisis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where id = (SELECT MAX(id) FROM solicitudanalisis)")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHAINGRESO = CType(unaFila.Item(1), String)
                s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                s.OBSERVACIONES = CType(unaFila.Item(6), String)
                s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                s.IDTECNICO = CType(unaFila.Item(9), Long)
                s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                s.TEMPERATURA = CType(unaFila.Item(12), Double)
                s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                s.IDFACTURA = CType(unaFila.Item(15), Long)
                s.WEB = CType(unaFila.Item(16), Integer)
                s.PERSONAL = CType(unaFila.Item(17), Integer)
                s.EMAIL = CType(unaFila.Item(18), Integer)
                s.FECHAENVIO = CType(unaFila.Item(19), String)
                s.MARCA = CType(unaFila.Item(20), Integer)
                s.ELIMINADO = CType(unaFila.Item(21), Integer)
                s.TAMBO = CType(unaFila.Item(22), Integer)
                s.PAGO = CType(unaFila.Item(23), Integer)
                s.IMPORTE = CType(unaFila.Item(24), Double)
                s.KMTS = CType(unaFila.Item(25), Integer)
                s.OBSINTERNAS = CType(unaFila.Item(26), String)
                s.CODIGO = CType(unaFila.Item(27), String)
                s.FECHAPROCESO = CType(unaFila.Item(28), String)
                s.MUESTREO = CType(unaFila.Item(29), Integer)
                s.LOGO = CType(unaFila.Item(30), Integer)
                s.INTERPRETACION = CType(unaFila.Item(31), String)
                s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimoid() As ArrayList
        Dim sql As String = "SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio,marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where id = (SELECT MAX(id) FROM solicitudanalisis)"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporproductor(ByVal texto As Long, ByVal fecd As String, ByVal fech As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where idproductor = " & texto & " and fechaingreso BETWEEN '" & fecd & "' and '" & fech & "' and eliminado=0 order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarportipoinforme(ByVal tipoinforme As Long, ByVal fecd As String, ByVal fech As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where idtipoinforme = " & tipoinforme & " and fechaingreso BETWEEN '" & fecd & "' and '" & fech & "' and eliminado=0 order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarSolicitudes(ByVal solicitudAnalisisId As Long, ByVal productor As Long, ByVal fecd As String, ByVal fech As String, ByVal tipoinforme As Long) As ArrayList
        Dim sql As String = "SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis WHERE eliminado = 0"

        ' Agregar condiciones solo si tienen valor
        If tipoinforme > 0 Then
            sql &= " AND idtipoinforme = " & tipoinforme
        End If

        If fecd <> "" And fech <> "" Then
            sql &= " AND fechaingreso BETWEEN '" & fecd & "' AND '" & fech & "'"
        End If

        If solicitudAnalisisId > 0 Then
            sql &= " AND id = " & solicitudAnalisisId
        End If

        If productor > 0 Then
            sql &= " AND idproductor = " & productor
        End If

        sql &= " ORDER BY fechaingreso DESC"

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporproductor2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where idproductor = " & texto & " and idtipoinforme=10 and eliminado=0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporproductor3(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where idproductor = " & texto & " and idtipoinforme=10 and eliminado=0 ORDER BY fechaingreso DESC LIMIT 6")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporproductorultimas3(ByVal texto As Long, ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where idproductor = " & texto & " and idtipoinforme=1 and eliminado=0 and id < " & ficha & " ORDER BY fechaingreso DESC LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and eliminado=0 order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas(ByVal fichadesde As Long, ByVal fichahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where id BETWEEN " & fichadesde & " And " & fichahasta & " and marca = 1 and eliminado=0 order by fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxproductor(ByVal fechadesde As String, ByVal fechahasta As String, ByVal idproductor As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' AND idproductor= " & idproductor & " and eliminado=0 order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxempresa(ByVal desde As String, ByVal hasta As String, ByVal idempresa As Long, ByVal tipoInforme As Integer) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaenvio BETWEEN '" & desde & "' And '" & hasta & "' AND idproductor= " & idempresa & " and idtipoinforme=               " & tipoInforme & " and marca=1 and eliminado=0 order by fechaenvio asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and eliminado=0 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfechacalidad(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and eliminado=0 AND idtipoinforme=10 order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfechacalidadempresa(ByVal fechadesde As String, ByVal fechahasta As String, ByVal idempresa As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and eliminado=0 AND idtipoinforme=10 AND idproductor= " & idempresa & " order by fechaingreso desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfechaxcant(ByVal fechadesde As String, ByVal fechahasta As String, ByVal contador As Integer) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and eliminado=0 ORDER BY RAND() LIMIT " & contador & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasagua() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 3")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichassubproductos() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 7")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasantibiograma() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 4")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichascalidad() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 10")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasnutricion() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 13")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichassuelos() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 14")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function desmarcar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET marca=0 WHERE marca=1 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'desmarca', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarpago(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET pago=0 WHERE pago=1 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'desmarca_pago', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object, ByVal usuario As dUsuario, ByVal fechaEnvio As String) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET marca=1, FECHAENVIO = '" & fechaEnvio & "' WHERE marca=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'marca', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarlogo(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET logo=1 WHERE logo=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'marcalogo', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarpago(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET pago=1 WHERE pago=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'marca_pago', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarpago2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET pago=" & obj.PAGO & ", web=1 WHERE pago=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'marca_pago', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar2(ByVal o As Object) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET marca=1 WHERE marca=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar3(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET marca=1, fechaenvio= '" & obj.FECHAENVIO & "' WHERE marca=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcareliminado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET eliminado=1 WHERE eliminado=0 and ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'marca', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_cantidad_muestras(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET nmuestras= " & obj.NMUESTRAS & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudanalisis', 'marca', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizarfechaenvio(ByVal o As Object, ByVal fecha As String) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET fechaenvio= '" & fecha & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizarfechaproceso(ByVal o As Object, ByVal fecha As String) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET fechaproceso= '" & fecha & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizarimporte(ByVal o As Object, ByVal importe As Double) As Boolean
        Dim obj As dSolicitudAnalisis = CType(o, dSolicitudAnalisis)
        Dim sql As String = "UPDATE solicitudanalisis SET importe= " & importe & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function listarfichascontrol() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasPAL() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idtipoinforme = 5")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasLeucosis() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idsubinforme = 23")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasBrucelosis() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idsubinforme = 52")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasRosaBengala() As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where marca = 0 And eliminado = 0 and idsubinforme = 22")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxproductorsinenviar(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where idproductor = " & texto & " and marca = 0 and eliminado=0 order by id desc ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlnutricion1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 13 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlnutricion2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 13 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlsuelos1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 14 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlsuelos2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 14 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlbrucelosis1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 15 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlbrucelosis2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 15 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlclechero1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 1 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlclechero2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 1 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlclechero5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 1 and eliminado=0 ORDER BY RAND() LIMIT 5")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlcalidad1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 10 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlcalidad2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 10 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlcalidad5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 10 and eliminado=0 ORDER BY RAND() LIMIT 5")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlcalidadvarios(ByVal fechadesde As String, ByVal fechahasta As String, ByVal faltan As Integer) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 10 and eliminado=0 ORDER BY RAND() LIMIT " & faltan & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlagua1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 3 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlagua2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 3 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlagua5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 3 and eliminado=0 ORDER BY RAND() LIMIT 5")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlsubproductos1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 7 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlsubproductos2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 7 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlsubproductos5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 7 and eliminado=0 ORDER BY RAND() LIMIT 5")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlserologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 8 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlserologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 8 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlpal1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 5 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlpal2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 5 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controltoxicologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 9 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controltoxicologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 9 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlparasitologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 6 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlparasitologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe,  kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 6 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlbacteriologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 4 and eliminado=0 ORDER BY RAND() LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function controlbacteriologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idproductor, idtipoinforme, idsubinforme, idtipoficha,observaciones, nmuestras, idmuestra, idtecnico, sinsolicitud, sinconservante, temperatura, derramadas, desvio, idfactura, web, personal, email, fechaenvio, marca, eliminado, tambo, pago, importe, kmts, ifnull(obsinternas,''), ifnull(codigo,''), fechaproceso, muestreo, logo, ifnull(interpretacion,''), fechamuestreo FROM solicitudanalisis where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "' and idtipoinforme = 4 and eliminado=0 ORDER BY RAND() LIMIT 2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    s.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(4), Integer)
                    s.IDTIPOFICHA = CType(unaFila.Item(5), Integer)
                    s.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s.NMUESTRAS = CType(unaFila.Item(7), Integer)
                    s.IDMUESTRA = CType(unaFila.Item(8), Integer)
                    s.IDTECNICO = CType(unaFila.Item(9), Long)
                    s.SINCOLICITUD = CType(unaFila.Item(10), Integer)
                    s.SINCONSERVANTE = CType(unaFila.Item(11), Integer)
                    s.TEMPERATURA = CType(unaFila.Item(12), Double)
                    s.DERRAMADAS = CType(unaFila.Item(13), Integer)
                    s.DESVIOAUTORIZADO = CType(unaFila.Item(14), Integer)
                    s.IDFACTURA = CType(unaFila.Item(15), Long)
                    s.WEB = CType(unaFila.Item(16), Integer)
                    s.PERSONAL = CType(unaFila.Item(17), Integer)
                    s.EMAIL = CType(unaFila.Item(18), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(19), String)
                    s.MARCA = CType(unaFila.Item(20), Integer)
                    s.ELIMINADO = CType(unaFila.Item(21), Integer)
                    s.TAMBO = CType(unaFila.Item(22), Integer)
                    s.PAGO = CType(unaFila.Item(23), Integer)
                    s.IMPORTE = CType(unaFila.Item(24), Double)
                    s.KMTS = CType(unaFila.Item(25), Integer)
                    s.OBSINTERNAS = CType(unaFila.Item(26), String)
                    s.CODIGO = CType(unaFila.Item(27), String)
                    s.FECHAPROCESO = CType(unaFila.Item(28), String)
                    s.MUESTREO = CType(unaFila.Item(29), Integer)
                    s.LOGO = CType(unaFila.Item(30), Integer)
                    s.INTERPRETACION = CType(unaFila.Item(31), String)
                    s.FECHAMUESTREO = CType(unaFila.Item(32), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    '*** Listados de solicitudes por tipo y subtipo de informe ******************************************************************************************************
    Public Function lista_sol_clechero(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 1 AND idsubinforme = 1 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_controlurea(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 1 AND idsubinforme = 32 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_completo(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 3 AND idsubinforme = 2 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_fqcompleto(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 3 AND idsubinforme = 29 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_bacteriologico(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 3 AND idsubinforme = 30 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_fqcloro(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 3 AND idsubinforme = 46 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_fqcondph(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 3 AND idsubinforme = 47 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_heterotroficos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 3 AND idsubinforme = 49 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_antibiograma(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 4 AND idsubinforme = 3 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_bactanque(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 4 AND idsubinforme = 10 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_aislamiento(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 4 AND idsubinforme = 34 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_pal(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 5 AND idsubinforme = 4 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_brucelosis_leche(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 15 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_parasitologia(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 6 AND idsubinforme = 5 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_paquete1(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 14 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_paquete2(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 15 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_paquete3(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 17 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_fq(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 20 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_microbiologia(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 35 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_otros(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 37 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_microfq(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 7 AND idsubinforme = 43 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_serologia(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 8 AND idsubinforme = 7 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_brucelosis(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 8 AND idsubinforme = 22 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_leucosis(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 8 AND idsubinforme = 23 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_anaclinicos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 8 AND idsubinforme = 26 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_patologia(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 9 AND idsubinforme = 8 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_toxicologia(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 9 AND idsubinforme = 11 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_patologiaotros(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 9 AND idsubinforme = 38 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_calidad(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 10 AND idsubinforme = 9 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_calidad_esporulados(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 10 AND idsubinforme = 9 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_todo(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 10 AND idsubinforme = 18 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_delvoycrios(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 10 AND idsubinforme = 19 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_composicion(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 10 AND idsubinforme = 28 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_enterobacterias(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 11 AND idsubinforme = 27 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_lactometros(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 12 AND idsubinforme = 25 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_chequeo(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 12 AND idsubinforme = 36 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_nutricion(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 13 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_suelos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 14 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_pradera(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 13 AND idsubinforme = 39 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_granos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 13 AND idsubinforme = 41 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_raciones(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 13 AND idsubinforme = 42 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function lista_sol_semen(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fechaingreso, idtipoinforme, idsubinforme, fechaenvio FROM solicitudanalisis WHERE fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND idtipoinforme = 99 AND idsubinforme = 12 AND marca = 1 AND eliminado = 0")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudAnalisis
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.IDSUBINFORME = CType(unaFila.Item(3), Integer)
                    s.FECHAENVIO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

   Public Function listar_informes_usuario_filtro(ByVal usuario_id As Integer, ByVal desde As String, ByVal hasta As String, ByVal idinforme As String) As ArrayList
        Dim sql As String = ""
        sql &= "SELECT na.ficha, sa.fechaingreso, ti.nombre, sa.nmuestras " &
               "FROM solicitudanalisis sa " &
               "INNER JOIN nuevoanalisis na ON na.ficha = sa.id " &
               "INNER JOIN analisis_usuario au ON au.analisis_id = na.analisis " &
               "INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme " &
               "WHERE sa.marca = 0 AND sa.eliminado = 0 AND au.usuario_id = " & usuario_id & " "

        If Not String.IsNullOrEmpty(desde) And Not String.IsNullOrEmpty(hasta) Then
            sql &= "AND sa.fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' "
        ElseIf Not String.IsNullOrEmpty(desde) Then
            sql &= "AND sa.fechaingreso >= '" & desde & "' "
        ElseIf Not String.IsNullOrEmpty(hasta) Then
            sql &= "AND sa.fechaingreso <= '" & hasta & "' "
        End If

        If Not String.IsNullOrEmpty(idinforme) Then
            sql &= "AND sa.id = " & idinforme & " "
        End If

        sql &= "GROUP BY sa.id ORDER BY na.ficha DESC"

        Try
            Dim lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                For Each fila As DataRow In Ds.Tables(0).Rows
                    Dim d As New dInformeAnalisis
                    d.FICHA = CType(fila.Item(0), Long)
                    d.FECHAINGRESO = CType(fila.Item(1), String)
                    d.NOMBRETIPOINFORME = CType(fila.Item(2), String)
                    d.NMUESTRAS = CType(fila.Item(3), Integer)
                    lista.Add(d)
                Next
                Return lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
