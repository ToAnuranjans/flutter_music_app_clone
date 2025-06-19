import 'package:client/core/theme/app_pallete.dart';
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';

class SignupPage extends StatefulWidget {
  const SignupPage({super.key});

  @override
  State<SignupPage> createState() => _SignupPageState();
}

class _SignupPageState extends State<SignupPage> {
  bool _agreed = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: Column(
        children: [
          TextFormField(
              decoration: const InputDecoration(hintText: 'Full Name')),
          TextFormField(
              decoration: const InputDecoration(hintText: 'Valid Email')),
          TextFormField(
              decoration: const InputDecoration(hintText: 'Phone Number')),
          TextFormField(
              decoration: const InputDecoration(hintText: 'Strong Password')),
          Row(
            children: [
              Checkbox(
                value: _agreed,
                onChanged: (value) {
                  setState(() {
                    _agreed = value ?? false;
                  });
                },
              ),
              Expanded(
                child: RichText(
                  text: TextSpan(
                    text: 'By checking the box you agree to our ',
                    style: const TextStyle(color: Colors.black),
                    children: [
                      TextSpan(
                        text: 'Terms and Conditions',
                        style: const TextStyle(
                            color: Colors.blue,
                            decoration: TextDecoration.underline),
                        recognizer: TapGestureRecognizer()
                          ..onTap = () {
                            // Handle link tap
                            showDialog(
                              context: context,
                              builder: (_) => const AlertDialog(
                                title: Text('Terms and Conditions'),
                                content:
                                    Text('Your terms and conditions go here.'),
                              ),
                            );
                          },
                      ),
                      const TextSpan(text: '.'),
                    ],
                  ),
                ),
              ),
            ],
          ),
          ElevatedButton(
            onPressed: () {},
            style: ElevatedButton.styleFrom(
              backgroundColor: AppPallete.greenColor,
              shape: const RoundedRectangleBorder(
                borderRadius: BorderRadius.zero, // <- removes rounding
              ),
            ),
            child: const Text('Signup'),
          ),
        ],
      ),
    );
  }
}
