Public Class pNuevoAnalisis_Factura
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis_Factura = CType(o, dNuevoAnalisis_Factura)
        Dim sql As String = "INSERT INTO nuevoanalisis_factura (id, ficha, muestra, analisis) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.ANALISIS & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis_factura', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis_Factura = CType(o, dNuevoAnalisis_Factura)
        Dim sql As String = "UPDATE nuevoanalisis_factura SET ficha =" & obj.FICHA & ", muestra ='" & obj.MUESTRA & "', analisis=" & obj.ANALISIS & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis_factura', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis_Factura = CType(o, dNuevoAnalisis_Factura)
        Dim sql As String = "DELETE FROM nuevoanalisis_factura WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis_factura', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function vaciar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis_Factura = CType(o, dNuevoAnalisis_Factura)
        Dim sql As String = "TRUNCATE TABLE nuevoanalisis_factura"
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis_factura', 'vaciar', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNuevoAnalisis_Factura
        Dim obj As dNuevoAnalisis_Factura = CType(o, dNuevoAnalisis_Factura)
        Dim n As New dNuevoAnalisis_Factura
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, analisis FROM nuevoanalisis_factura WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.ANALISIS = CType(unaFila.Item(3), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarrepetidas(ByVal o As Object) As dNuevoAnalisis_Factura
        Dim obj As dNuevoAnalisis_Factura = CType(o, dNuevoAnalisis_Factura)
        Dim n As New dNuevoAnalisis_Factura
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, analisis FROM nuevoanalisis_factura WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.ANALISIS = CType(unaFila.Item(3), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, analisis FROM nuevoanalisis_factura order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.ANALISIS = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardistintosanalisis(ByVal ficha As Long) As ArrayList
        Dim sql As String = "SELECT DISTINCT analisis FROM nuevoanalisis_factura WHERE ficha = " & ficha & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM nuevoanalisis_factura order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, analisis FROM nuevoanalisis_factura WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.ANALISIS = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra FROM nuevoanalisis_factura WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  id, ficha, muestra, analisis FROM nuevoanalisis_factura WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.ANALISIS = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, analisis FROM nuevoanalisis_factura WHERE ficha = " & ficha & " AND muestra = '" & muestra & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.ANALISIS = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanalisis(ByVal idficha As Long, ByVal idana As Integer) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, analisis FROM nuevoanalisis_factura WHERE ficha = " & idficha & " AND analisis = " & idana & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis_Factura
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.ANALISIS = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
