Public Class pLicencias
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLicencias = CType(o, dLicencias)
        Dim sql As String = "INSERT INTO licencias (id, idusuario, desde, hasta, dias, aprobada) VALUES (" & obj.ID & ", " & obj.IDUSUARIO & ", '" & obj.DESDE & "', '" & obj.HASTA & "', " & obj.DIAS & ", " & obj.APROBADA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLicencias = CType(o, dLicencias)
        Dim sql As String = "UPDATE licencias SET idusuario = " & obj.IDUSUARIO & ", desde = '" & obj.DESDE & "', hasta = '" & obj.HASTA & "', dias = " & obj.DIAS & ", aprobada = " & obj.APROBADA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLicencias = CType(o, dLicencias)
        Dim sql As String = "DELETE FROM licencias WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       
        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dLicencias
        Dim obj As dLicencias = CType(o, dLicencias)
        Dim l As New dLicencias
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idusuario, desde, hasta, dias, aprobada FROM licencias WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDUSUARIO = CType(unaFila.Item(1), Integer)
                l.DESDE = CType(unaFila.Item(2), String)
                l.HASTA = CType(unaFila.Item(3), String)
                l.DIAS = CType(unaFila.Item(4), Integer)
                l.APROBADA = CType(unaFila.Item(5), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcaraprobada(ByVal o As Object) As Boolean
        Dim obj As dLicencias = CType(o, dLicencias)
        Dim sql As String = "UPDATE licencias SET aprobada = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcaraprobada(ByVal o As Object) As Boolean
        Dim obj As dLicencias = CType(o, dLicencias)
        Dim sql As String = "UPDATE licencias SET aprobada = 0 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idusuario, desde, hasta, dias, aprobada FROM licencias ORDER BY desde DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicencias
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDUSUARIO = CType(unaFila.Item(1), Integer)
                    l.DESDE = CType(unaFila.Item(2), String)
                    l.HASTA = CType(unaFila.Item(3), String)
                    l.DIAS = CType(unaFila.Item(4), Integer)
                    l.APROBADA = CType(unaFila.Item(5), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinaprobar() As ArrayList
        Dim sql As String = "SELECT id, idusuario, desde, hasta, dias, aprobada FROM licencias where aprobada = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicencias
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDUSUARIO = CType(unaFila.Item(1), Integer)
                    l.DESDE = CType(unaFila.Item(2), String)
                    l.HASTA = CType(unaFila.Item(3), String)
                    l.DIAS = CType(unaFila.Item(4), Integer)
                    l.APROBADA = CType(unaFila.Item(5), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, idusuario, desde, hasta, dias, aprobada FROM licencias WHERE year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicencias
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDUSUARIO = CType(unaFila.Item(1), Integer)
                    l.DESDE = CType(unaFila.Item(2), String)
                    l.HASTA = CType(unaFila.Item(3), String)
                    l.DIAS = CType(unaFila.Item(4), Integer)
                    l.APROBADA = CType(unaFila.Item(5), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanoxusuario(ByVal ano As Integer, ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, idusuario, desde, hasta, dias, aprobada FROM licencias WHERE year(desde) = " & ano & " AND idusuario = " & idusuario & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicencias
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDUSUARIO = CType(unaFila.Item(1), Integer)
                    l.DESDE = CType(unaFila.Item(2), String)
                    l.HASTA = CType(unaFila.Item(3), String)
                    l.DIAS = CType(unaFila.Item(4), Integer)
                    l.APROBADA = CType(unaFila.Item(5), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer, ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, idusuario, desde, hasta, dias, aprobada FROM licencias WHERE idusuario= " & idusuario & " AND year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicencias
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDUSUARIO = CType(unaFila.Item(1), Integer)
                    l.DESDE = CType(unaFila.Item(2), String)
                    l.HASTA = CType(unaFila.Item(3), String)
                    l.DIAS = CType(unaFila.Item(4), Integer)
                    l.APROBADA = CType(unaFila.Item(5), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
