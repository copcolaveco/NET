Public Class pSolicitudNutricion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudNutricion = CType(o, dSolicitudNutricion)
        Dim sql As String = "INSERT INTO solicitud_nutricion (id, ficha, muestra, mga, mgb, ensilados, pasturas, extetereo, nida, micotoxinas, don, afla, zeara, proteinas, materiaseca, ph, fibraefectiva, clostridios, timac, timacproteina, fibraneutra, fibraacida) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.MGA & ", " & obj.MGB & ", " & obj.ENSILADOS & "," & obj.PASTURAS & ", " & obj.EXTETEREO & ", " & obj.NIDA & ", " & obj.MICOTOXINAS & ", " & obj.DON & ", " & obj.AFLA & ", " & obj.ZEARA & ", " & obj.PROTEINAS & ", " & obj.MATERIASECA & ", " & obj.PH & ", " & obj.FIBRAEFECTIVA & ", " & obj.CLOSTRIDIOS & ", " & obj.TIMAC & ", " & obj.TIMACPROTEINA & ", " & obj.FIBRANEUTRA & ", " & obj.FIBRAACIDA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_nutricion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudNutricion = CType(o, dSolicitudNutricion)
        Dim sql As String = "UPDATE solicitud_nutricion SET ficha= " & obj.FICHA & ", muestra='" & obj.MUESTRA & "', mga=" & obj.MGA & ",mgb=" & obj.MGB & ",ensilados=" & obj.ENSILADOS & ",pasturas=" & obj.PASTURAS & ", extetereo=" & obj.EXTETEREO & ", nida=" & obj.NIDA & ", micotoxinas=" & obj.MICOTOXINAS & ", don=" & obj.DON & ", afla=" & obj.AFLA & ", zeara=" & obj.ZEARA & ", proteinas=" & obj.PROTEINAS & ", ph=" & obj.PH & ", fibraefectiva=" & obj.FIBRAEFECTIVA & ", clostridios=" & obj.CLOSTRIDIOS & ", timac=" & obj.TIMAC & ", timacproteina=" & obj.TIMACPROTEINA & ", fibraneutra=" & obj.FIBRANEUTRA & ", fibraacida=" & obj.FIBRAACIDA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_nutricion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudNutricion = CType(o, dSolicitudNutricion)
        Dim sql As String = "DELETE FROM solicitud_nutricion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_nutricion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudNutricion = CType(o, dSolicitudNutricion)
        Dim sql As String = "DELETE FROM solicitud_nutricion WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_nutricion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSolicitudNutricion
        Dim obj As dSolicitudNutricion = CType(o, dSolicitudNutricion)
        Dim sn As New dSolicitudNutricion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, mga, mgb, ensilados, pasturas, extetereo, nida, micotoxinas, don, afla, zeara, proteinas, materiaseca, ph, fibraefectiva, clostridios, timac, timacproteina, fibraneutra, fibraacida FROM solicitud_nutricion WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                sn.ID = CType(unaFila.Item(0), Long)
                sn.FICHA = CType(unaFila.Item(1), Long)
                sn.MUESTRA = CType(unaFila.Item(2), String)
                sn.MGA = CType(unaFila.Item(3), Integer)
                sn.MGB = CType(unaFila.Item(4), Integer)
                sn.ENSILADOS = CType(unaFila.Item(5), Integer)
                sn.PASTURAS = CType(unaFila.Item(6), Integer)
                sn.EXTETEREO = CType(unaFila.Item(7), Integer)
                sn.NIDA = CType(unaFila.Item(8), Integer)
                sn.MICOTOXINAS = CType(unaFila.Item(9), Integer)
                sn.DON = CType(unaFila.Item(10), Integer)
                sn.AFLA = CType(unaFila.Item(11), Integer)
                sn.ZEARA = CType(unaFila.Item(12), Integer)
                sn.PROTEINAS = CType(unaFila.Item(13), Integer)
                sn.MATERIASECA = CType(unaFila.Item(14), Integer)
                sn.PH = CType(unaFila.Item(15), Integer)
                sn.FIBRAEFECTIVA = CType(unaFila.Item(16), Integer)
                sn.CLOSTRIDIOS = CType(unaFila.Item(17), Integer)
                sn.TIMAC = CType(unaFila.Item(18), Integer)
                sn.TIMACPROTEINA = CType(unaFila.Item(19), Integer)
                sn.FIBRANEUTRA = CType(unaFila.Item(20), Integer)
                sn.FIBRAACIDA = CType(unaFila.Item(21), Integer)
                Return sn
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dSolicitudNutricion
        Dim obj As dSolicitudNutricion = CType(o, dSolicitudNutricion)
        Dim sn As New dSolicitudNutricion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, mga, mgb, ensilados, pasturas, extetereo, nida, micotoxinas, don, afla, zeara, proteinas, materiaseca, ph, fibraefectiva, clostridios, timac, timacproteina, fibraneutra, fibraacida FROM solicitud_nutricion WHERE ficha = " & obj.FICHA & " AND muestra= '" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                sn.ID = CType(unaFila.Item(0), Long)
                sn.FICHA = CType(unaFila.Item(1), Long)
                sn.MUESTRA = CType(unaFila.Item(2), String)
                sn.MGA = CType(unaFila.Item(3), Integer)
                sn.MGB = CType(unaFila.Item(4), Integer)
                sn.ENSILADOS = CType(unaFila.Item(5), Integer)
                sn.PASTURAS = CType(unaFila.Item(6), Integer)
                sn.EXTETEREO = CType(unaFila.Item(7), Integer)
                sn.NIDA = CType(unaFila.Item(8), Integer)
                sn.MICOTOXINAS = CType(unaFila.Item(9), Integer)
                sn.DON = CType(unaFila.Item(10), Integer)
                sn.AFLA = CType(unaFila.Item(11), Integer)
                sn.ZEARA = CType(unaFila.Item(12), Integer)
                sn.PROTEINAS = CType(unaFila.Item(13), Integer)
                sn.MATERIASECA = CType(unaFila.Item(14), Integer)
                sn.PH = CType(unaFila.Item(15), Integer)
                sn.FIBRAEFECTIVA = CType(unaFila.Item(16), Integer)
                sn.CLOSTRIDIOS = CType(unaFila.Item(17), Integer)
                sn.TIMAC = CType(unaFila.Item(18), Integer)
                sn.TIMACPROTEINA = CType(unaFila.Item(19), Integer)
                sn.FIBRANEUTRA = CType(unaFila.Item(20), Integer)
                sn.FIBRAACIDA = CType(unaFila.Item(21), Integer)
                Return sn
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, mga, mgb, ensilados, pasturas, extetereo, nida, micotoxinas, don, afla, zeara, proteinas, materiaseca, ph, fibraefectiva, clostridios, timac, timacproteina, fibraneutra, fibraacida FROM solicitud_nutricion ORDER BY id DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim sn As New dSolicitudNutricion
                    sn.ID = CType(unaFila.Item(0), Long)
                    sn.FICHA = CType(unaFila.Item(1), Long)
                    sn.MUESTRA = CType(unaFila.Item(2), String)
                    sn.MGA = CType(unaFila.Item(3), Integer)
                    sn.MGB = CType(unaFila.Item(4), Integer)
                    sn.ENSILADOS = CType(unaFila.Item(5), Integer)
                    sn.PASTURAS = CType(unaFila.Item(6), Integer)
                    sn.EXTETEREO = CType(unaFila.Item(7), Integer)
                    sn.NIDA = CType(unaFila.Item(8), Integer)
                    sn.MICOTOXINAS = CType(unaFila.Item(9), Integer)
                    sn.DON = CType(unaFila.Item(10), Integer)
                    sn.AFLA = CType(unaFila.Item(11), Integer)
                    sn.ZEARA = CType(unaFila.Item(12), Integer)
                    sn.PROTEINAS = CType(unaFila.Item(13), Integer)
                    sn.MATERIASECA = CType(unaFila.Item(14), Integer)
                    sn.PH = CType(unaFila.Item(15), Integer)
                    sn.FIBRAEFECTIVA = CType(unaFila.Item(16), Integer)
                    sn.CLOSTRIDIOS = CType(unaFila.Item(17), Integer)
                    sn.TIMAC = CType(unaFila.Item(18), Integer)
                    sn.TIMACPROTEINA = CType(unaFila.Item(19), Integer)
                    sn.FIBRANEUTRA = CType(unaFila.Item(20), Integer)
                    sn.FIBRAACIDA = CType(unaFila.Item(21), Integer)
                    Lista.Add(sn)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM solicitud_nutricion ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim sn As New dSolicitudNutricion
                    sn.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(sn)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, mga, mgb, ensilados, pasturas, extetereo, nida, micotoxinas, don, afla, zeara, proteinas, materiaseca, ph, fibraefectiva, clostridios, timac, timacproteina, fibraneutra, fibraacida FROM solicitud_nutricion where ficha = " & texto & " order by id desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim sn As New dSolicitudNutricion
                    sn.ID = CType(unaFila.Item(0), Long)
                    sn.FICHA = CType(unaFila.Item(1), Long)
                    sn.MUESTRA = CType(unaFila.Item(2), String)
                    sn.MGA = CType(unaFila.Item(3), Integer)
                    sn.MGB = CType(unaFila.Item(4), Integer)
                    sn.ENSILADOS = CType(unaFila.Item(5), Integer)
                    sn.PASTURAS = CType(unaFila.Item(6), Integer)
                    sn.EXTETEREO = CType(unaFila.Item(7), Integer)
                    sn.NIDA = CType(unaFila.Item(8), Integer)
                    sn.MICOTOXINAS = CType(unaFila.Item(9), Integer)
                    sn.DON = CType(unaFila.Item(10), Integer)
                    sn.AFLA = CType(unaFila.Item(11), Integer)
                    sn.ZEARA = CType(unaFila.Item(12), Integer)
                    sn.PROTEINAS = CType(unaFila.Item(13), Integer)
                    sn.MATERIASECA = CType(unaFila.Item(14), Integer)
                    sn.PH = CType(unaFila.Item(15), Integer)
                    sn.FIBRAEFECTIVA = CType(unaFila.Item(16), Integer)
                    sn.CLOSTRIDIOS = CType(unaFila.Item(17), Integer)
                    sn.TIMAC = CType(unaFila.Item(18), Integer)
                    sn.TIMACPROTEINA = CType(unaFila.Item(19), Integer)
                    sn.FIBRANEUTRA = CType(unaFila.Item(20), Integer)
                    sn.FIBRAACIDA = CType(unaFila.Item(21), Integer)
                    Lista.Add(sn)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, mga, mgb, ensilados, pasturas, extetereo, nida, micotoxinas, don, afla, zeara, proteinas, materiaseca, ph, fibraefectiva, clostridios, timac, timacproteina, fibraneutra, fibraacida FROM solicitud_nutricion where ficha = " & texto & " order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim sn As New dSolicitudNutricion
                    sn.ID = CType(unaFila.Item(0), Long)
                    sn.FICHA = CType(unaFila.Item(1), Long)
                    sn.MUESTRA = CType(unaFila.Item(2), String)
                    sn.MGA = CType(unaFila.Item(3), Integer)
                    sn.MGB = CType(unaFila.Item(4), Integer)
                    sn.ENSILADOS = CType(unaFila.Item(5), Integer)
                    sn.PASTURAS = CType(unaFila.Item(6), Integer)
                    sn.EXTETEREO = CType(unaFila.Item(7), Integer)
                    sn.NIDA = CType(unaFila.Item(8), Integer)
                    sn.MICOTOXINAS = CType(unaFila.Item(9), Integer)
                    sn.DON = CType(unaFila.Item(10), Integer)
                    sn.AFLA = CType(unaFila.Item(11), Integer)
                    sn.ZEARA = CType(unaFila.Item(12), Integer)
                    sn.PROTEINAS = CType(unaFila.Item(13), Integer)
                    sn.MATERIASECA = CType(unaFila.Item(14), Integer)
                    sn.PH = CType(unaFila.Item(15), Integer)
                    sn.FIBRAEFECTIVA = CType(unaFila.Item(16), Integer)
                    sn.CLOSTRIDIOS = CType(unaFila.Item(17), Integer)
                    sn.TIMAC = CType(unaFila.Item(18), Integer)
                    sn.TIMACPROTEINA = CType(unaFila.Item(19), Integer)
                    sn.FIBRANEUTRA = CType(unaFila.Item(20), Integer)
                    sn.FIBRAACIDA = CType(unaFila.Item(21), Integer)
                    Lista.Add(sn)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
  
End Class
