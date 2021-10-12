Public Class pControlAuxWeb_com
    Inherits Conectoras.ConexionMySQL_tools_com
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dControlAuxWeb_com = CType(o, dControlAuxWeb_com)
        Dim sql As String = "INSERT INTO somaticas (id, ficha, fecha, productor, muestra, rc, tambo) VALUES (" & obj.ID & ", '" & obj.FICHA & "','" & obj.FECHA & "', " & obj.PRODUCTOR & ", '" & obj.MUESTRA & "'," & obj.RC & "," & obj.TAMBO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dControlAuxWeb_com = CType(o, dControlAuxWeb_com)
        Dim sql As String = "UPDATE somaticas SET ficha = '" & obj.FICHA & "',  fecha ='" & obj.FECHA & "', productor =" & obj.PRODUCTOR & ",muestra='" & obj.MUESTRA & "',rc=" & obj.RC & ",tambo=" & obj.TAMBO & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificartambo(ByVal ficha As Long, ByVal tambo As Integer) As Boolean
        'Dim obj As dControlAuxWeb_com = CType(o, dControlAuxWeb_com)
        Dim sql As String = "UPDATE somaticas SET tambo = " & tambo & " WHERE ficha = " & ficha & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dControlAuxWeb_com = CType(o, dControlAuxWeb_com)
        Dim sql As String = "DELETE FROM somaticas WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControlAuxWeb_com
        Dim obj As dControlAuxWeb_com = CType(o, dControlAuxWeb_com)
        Dim c As New dControlAuxWeb_com
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, productor, muestra, rc, tambo FROM somaticas WHERE ficha = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), String)
                c.FECHA = CType(unaFila.Item(2), String)
                c.PRODUCTOR = CType(unaFila.Item(3), Integer)
                c.MUESTRA = CType(unaFila.Item(4), String)
                c.RC = CType(unaFila.Item(5), Integer)
                c.TAMBO = CType(unaFila.Item(6), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, productor, muestra, rc, tambo FROM somaticas order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlAuxWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.PRODUCTOR = CType(unaFila.Item(3), Integer)
                    c.MUESTRA = CType(unaFila.Item(4), String)
                    c.RC = CType(unaFila.Item(5), Integer)
                    c.TAMBO = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, productor, muestra, rc, tambo FROM somaticas where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlAuxWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.PRODUCTOR = CType(unaFila.Item(3), Integer)
                    c.MUESTRA = CType(unaFila.Item(4), String)
                    c.RC = CType(unaFila.Item(5), Integer)
                    c.TAMBO = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinsubir(ByVal ultimonumero As Long) As ArrayList
        Dim sql As String = ("SELECT DISTINCT (id) FROM somaticas where ficha > " & ultimonumero & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlAuxWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinsubir2(ByVal ficha As Long) As ArrayList

        Dim sql As String = ("SELECT MIN(id), ficha, fecha, productor, muestra, rc, tambo FROM somaticas where ficha = " & ficha & " group by ficha, fecha, productor, muestra, rc, tambo Order by muestra asc")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlAuxWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.PRODUCTOR = CType(unaFila.Item(3), Integer)
                    c.MUESTRA = CType(unaFila.Item(4), String)
                    c.RC = CType(unaFila.Item(5), Integer)
                    c.TAMBO = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, productor, muestra, rc, tambo FROM somaticas where ficha = '" & texto & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlAuxWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.PRODUCTOR = CType(unaFila.Item(3), Integer)
                    c.MUESTRA = CType(unaFila.Item(4), String)
                    c.RC = CType(unaFila.Item(5), Integer)
                    c.TAMBO = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinrepetir(ByVal numficha As Long) As ArrayList
        Dim sql As String = ("SELECT DISTINCT (muestra) FROM somaticas where ficha = " & numficha & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlAux
                    c.MUESTRA = CType(unaFila.Item(0), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
