Public Class pCalidadSolicitud
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitud = CType(o, dCalidadSolicitud)
        Dim sql As String = "INSERT INTO calidad_solicitud (id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo) VALUES (" & obj.ID & ", " & obj.ficha & "," & obj.RB & ", " & obj.RC & ", " & obj.COMPOSICION & "," & obj.CRIOSCOPIA & ", " & obj.INHIBIDORES & ", " & obj.ESPORULADOS & ", " & obj.UREA & ", " & obj.TERMOFILOS & ", " & obj.PSICROTROFOS & ", " & obj.CRIOSCOPIA_CRIOSCOPO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitud = CType(o, dCalidadSolicitud)
        Dim sql As String = "UPDATE calidad_solicitud SET rb=" & obj.RB & ",rc=" & obj.RC & ",composicion=" & obj.COMPOSICION & ",crioscopia=" & obj.CRIOSCOPIA & ", inhibidores=" & obj.INHIBIDORES & ", esporulados=" & obj.ESPORULADOS & ", urea=" & obj.UREA & ", termofilos=" & obj.TERMOFILOS & ",psicrotrofos=" & obj.PSICROTROFOS & ",crioscopia_crioscopo=" & obj.CRIOSCOPIA_CRIOSCOPO & " WHERE ficha = " & obj.ficha

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadSolicitud = CType(o, dCalidadSolicitud)
        Dim sql As String = "DELETE FROM calidad_solicitud WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_solicitud', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCalidadSolicitud
        Dim obj As dCalidadSolicitud = CType(o, dCalidadSolicitud)
        Dim c As New dCalidadSolicitud
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo FROM calidad_solicitud WHERE ficha = " & obj.ficha & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.ficha = CType(unaFila.Item(1), Long)
                c.RB = CType(unaFila.Item(2), Integer)
                c.RC = CType(unaFila.Item(3), Double)
                c.COMPOSICION = CType(unaFila.Item(4), Double)
                c.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                c.INHIBIDORES = CType(unaFila.Item(6), Integer)
                c.ESPORULADOS = CType(unaFila.Item(7), Integer)
                c.UREA = CType(unaFila.Item(8), Integer)
                c.TERMOFILOS = CType(unaFila.Item(9), Integer)
                c.PSICROTROFOS = CType(unaFila.Item(10), Integer)
                c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(11), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo FROM calidad_solicitud WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitud
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ficha = CType(unaFila.Item(1), Long)
                    c.RB = CType(unaFila.Item(2), Integer)
                    c.RC = CType(unaFila.Item(3), Double)
                    c.COMPOSICION = CType(unaFila.Item(4), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                    c.INHIBIDORES = CType(unaFila.Item(6), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(7), Integer)
                    c.UREA = CType(unaFila.Item(8), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(9), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(10), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM calidad_solicitud WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitud
                    c.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo FROM calidad_solicitud where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitud
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ficha = CType(unaFila.Item(1), Long)
                    c.RB = CType(unaFila.Item(2), Integer)
                    c.RC = CType(unaFila.Item(3), Double)
                    c.COMPOSICION = CType(unaFila.Item(4), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                    c.INHIBIDORES = CType(unaFila.Item(6), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(7), Integer)
                    c.UREA = CType(unaFila.Item(8), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(9), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(10), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo FROM calidad_solicitud where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitud
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ficha = CType(unaFila.Item(1), Long)
                    c.RB = CType(unaFila.Item(2), Integer)
                    c.RC = CType(unaFila.Item(3), Double)
                    c.COMPOSICION = CType(unaFila.Item(4), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                    c.INHIBIDORES = CType(unaFila.Item(6), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(7), Integer)
                    c.UREA = CType(unaFila.Item(8), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(9), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(10), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo FROM calidad_solicitud where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitud
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ficha = CType(unaFila.Item(1), Long)
                    c.RB = CType(unaFila.Item(2), Integer)
                    c.RC = CType(unaFila.Item(3), Double)
                    c.COMPOSICION = CType(unaFila.Item(4), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                    c.INHIBIDORES = CType(unaFila.Item(6), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(7), Integer)
                    c.UREA = CType(unaFila.Item(8), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(9), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(10), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, rb, rc, composicion, crioscopia, inhibidores, esporulados, urea, termofilos, psicrotrofos, crioscopia_crioscopo FROM calidad_solicitud where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadSolicitud
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ficha = CType(unaFila.Item(1), Long)
                    c.RB = CType(unaFila.Item(2), Integer)
                    c.RC = CType(unaFila.Item(3), Double)
                    c.COMPOSICION = CType(unaFila.Item(4), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                    c.INHIBIDORES = CType(unaFila.Item(6), Integer)
                    c.ESPORULADOS = CType(unaFila.Item(7), Integer)
                    c.UREA = CType(unaFila.Item(8), Integer)
                    c.TERMOFILOS = CType(unaFila.Item(9), Integer)
                    c.PSICROTROFOS = CType(unaFila.Item(10), Integer)
                    c.CRIOSCOPIA_CRIOSCOPO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
